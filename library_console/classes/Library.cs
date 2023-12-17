using System;
using System.Collections.Generic;

namespace library_console.classes
{
    public class Library {
        public string Name;
        public List<Member> Members;
        public List<Book> Books;

        public Library() {
            Name = "my_library";
            Members = new List<Member>();
            Books = new List<Book>();
        }
        public Library(string name) { 
            Name = name;
            Members = new List<Member>();
            Books = new List<Book>();
        }
        public Library(string name, List<Member>? members = null, List<Book>? books = null) { 
            Name = name; 
            Members = members ?? new List<Member>();
            Books = books ?? new List<Book>();
        }
        public bool addMember(Member member) {
            if (member != null && !Members.Contains(member)) {
                Date d = new Date();
                Log.writeLog($"MEMBER {member.Id} was ADDED to library", d.dateTime);
                Members.Add(member);

                return true;
            }
            return false;
        }
        public bool removeMember(Member member){
            if (member != null && Members.Contains(member)) {
                if (member.BorrowedBooks.Count() == 0) {
                    Date d = new Date();
                    Log.writeLog($"MEMBER {member.Id} was REMOVED from library", d.dateTime);
                    Members.Remove(member);

                    return true;
                }
            }
            return false;
        }
        public bool addBook(Book book) {
            if (book != null && !Books.Contains(book)) {
                Date d = new Date();
                Log.writeLog($"BOOK {book.Id} was ADDED to library", d.dateTime);
                Books.Add(book);

                return true;
            }
            return false;
        }
        public bool removeBook(Book book) { // removes book from library list (example: book being decommissioned)
            if (book != null && Books.Contains(book)) {
                if (!book.IsBorrowed) {
                    Date d = new Date();
                    Log.writeLog($"BOOK {book.Id} was REMOVED from library", d.dateTime);
                    Books.Remove(book);

                    return true;
                }
            }
            return false;
        }
        public Member? getMemberById(string memberId) {
            foreach (var member in Members) {
                if (member.Id == memberId) {
                    return member;
                }
            }
            return null;
        }
        public Book? getBookById(string bookId) {
            foreach (var book in Books) {
                if (book.Id == bookId) {
                    return book;
                }
            }
            return null;
        }
        public bool lentBook(Book bookToLent, Member borrower) {
            if(!Books.Contains(bookToLent)) { return false; }

            if (!bookToLent.IsBorrowed) { //book can only be lent if it's not borrowed by some other member already
                Date now = new Date();
                string lentDate = now.date;
                string lentDateTime = now.dateTime;
                
                bookToLent.IsBorrowed = true;
                bookToLent.Borrower = borrower.Id;
                bookToLent.DateLent = lentDate;
                bookToLent.DateLentUntil = now.addDays(lentDate, 20);
                Log.writeLog($"BOOK {bookToLent.Id} was LENT to MEMBER {borrower.Id}", lentDateTime);
                borrower.addBorrowedBook(bookToLent.Id);

                return true;
            }
            return false;
        }
        public void extendLent(Book book, int numberOfDays) {
            if (book.IsBorrowed) {
                Date now = new Date();
                string newDate = new Date().addDays(book.DateLentUntil, numberOfDays);
                Log.writeLog($"RETURN DATE of BOOK {book.Id} extended by {numberOfDays} days, NEW RETURN DATE: {newDate}", now.dateTime);
                book.DateLentUntil = newDate;
            }
        }
        public bool returnBook(Book book) {
            if (!Books.Contains(book)) { return false; }

            Member? borrower = getMemberById(book.Borrower);

            if (borrower != null) {
                Date now = new Date();
                string returnDate = now.date;
                string returnDateTime = now.dateTime;

                book.IsBorrowed = false;
                book.Borrower = null;
                book.DateReturned = returnDate;
                book.DateLent = null;
                book.DateLentUntil = null;
                Log.writeLog($"BOOK {book.Id} was RETURNED", returnDateTime);
                borrower.removeBorrowedBook(book.Id);
            }
            return false;
        }
    }
}
