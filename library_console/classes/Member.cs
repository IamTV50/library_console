using System;
using System.Collections.Generic;

namespace library_console.classes
{
    public class Member {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public List<string>? BorrowedBooks { get; set; }

        public Member() {
            Id = string.Empty;
            FirstName = string.Empty;
            LastName = string.Empty;
            Email = string.Empty;
            PhoneNumber = null;
            BorrowedBooks = new List<string>();
        }
        public Member(string id, string fistName, string lastName, string email, string? phoneNum = null) {
            Id = id;
            FirstName = fistName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNum;
            BorrowedBooks = new List<string>(); //member can't have any borrowed books when opening new "account"
        }
        public void changeInfo(string fistName, string lastName, string email, string? phoneNum = null) {
            FirstName = fistName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNum;
        }
        public void addBorrowedBook(string bookId) {
            if (BorrowedBooks != null && !BorrowedBooks.Contains(bookId)) {
                BorrowedBooks.Add(bookId);
            }
        }
        public void removeBorrowedBook(string bookId) {
            if (BorrowedBooks != null && BorrowedBooks.Contains(bookId)) {
                BorrowedBooks.Remove(bookId);
            }
        }
    }
}
