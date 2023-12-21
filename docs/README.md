# simpe documentation

Trying to explain what each class and its methods purpose is (with usage examples).

# Table of contents:

- [class Member](#class-member)
	- [Member](#member)
	- [changeInfo](#changeinfo)
	- [addBorrowedBook](#addborrowedbook)
	- [removeBorrowedBook](#removeBorrowedBook)
- [class Book](#class-book)
	- [Book](#book)
	- [addGenre](#addgenre)
	- [removeGenre](#removegenre)
- [class Library](#class-library)
	- [Library](#library)
	- [addMember](#addmember)
	- [removeMember](#removemember)
	- [addBook](#addbook)
	- [removeBook](#removebook)
	- [getMemberById](#getmemberbyid)
	- [getBookById](#getbookbyid)
	- [lentBook](#lentbook)
	- [extendLent](#extendlent)
	- [returnBook](#returnbook)
- [class Date](#class-date)
	- [Date](#date)
	- [addDays](#adddays)
- [class Log](#class-log)
	- [writeLog](#writelog)

---

# class Member

## Member
Class Member has 2 diferent constructor functions.

**Constructor method `Member()`** is constructor that doesn't take any arguments.

Usaage example: 
```cs
Member member = new Member();
```

**Constructor method `Member(string id, string fistName, string lastName, string email, string? phoneNum = null)`** is constructor that takes arguments.

Different usage examples:
```cs
Member jane = new Member("generatedId", "Jane", "Doe", "jdoe@mail.com");
Member harry = new Member("generatedId", "Harry", "Potter", "iamthewizard@mail.com", "123123123");
```

## changeInfo
Method **changeInfo** is type *void* and allows user to change member information.

Usage example:
```cs
Member harry = new Member("generatedId", "Harry", "Potter", "iamthewizard@mail.com", "123123123");

//definitely not the cleanest way but it works...
harry.changeInfo(harry.FirstName, harry.LastName, "magicman@mail.com", harry.PhoneNumber); // changed email and keept everything else by using getters
```

## addBorrowedBook
Method **addBorrowedBook** adds *Id* of the book that memeber borrowed, to the *BorrowedBooks* property (list of strings). Member can not have same book marked as borrowed (2 of same Ids in the BorrowedBooks list) at the same time for obvious reasons.

Usaage example: 
```cs
Member harry = new Member("generatedId", "Harry", "Potter", "iamthewizard@mail.com");

harry.addBorrowedBook("somebookID"); //adds id "somebookID" to BorrowedBooks list
```

## removeBorrowedBook
Method **removeBorrowedBook** removes *Id* of the book that memeber has borrowed, from the *BorrowedBooks* property (list of strings).

Usaage example: 
```cs
Member harry = new Member("generatedId", "Harry", "Potter", "iamthewizard@mail.com");

harry.addBorrowedBook("somebookID"); //adds id "somebookID" to BorrowedBooks list

harry.removeBorrowedBook("1234"); //does nothing as the member does has not borrowd book with id of "1234"
harry.removeBorrowedBook("somebookID"); //removes book with "" from BorrowedBooks list
```

# class Book

## Book
Class Book has 2 diferent constructor functions.

**Constructor method `Book()`** is constructor that doesn't take any arguments.

Usaage example: 
```cs
Book myBook = new Book();
```

**Constructor method `Book(string id, string title, string author, List<string> genre)`** is constructor that takes arguments.

Usaage example: 
```cs
Book myBook = new Book("generatedId", "bookTitle", "author", <already defined list>); //in case you already have defined genre list

Book myBook = new Book("generatedId", "bookTitle", "author", new List<string>()); //if you want genre list to be empty
```

Book objects should first be added to library before they could be *lent out* to a library member.

## addGenre
Method **addGenre** is type *void* and adds a genre (provided string argument) to *Genre* property (list of strings) in case it does not yet contain given genre.

Usaage examples: 
```cs
Book myBook = new Book();
myBook.addGenre("drama"); //adds "drama" genre to myBook
myBook.addGenre("drama"); //does nothing, since myBook is already contains "drama" genre
```

## removeGenre
Method **removeGenre** is type *void* and removes a genre (provided string argument) from *Genre* property (list of strings) if the list contains a given genre.

Usaage examples: 
```cs
Book myBook = new Book();
myBook.addGenre("drama"); // adds "drama" genre to myBook

myBook.removeGenre("comedy"); // does nothing, since "comedy" is not in the genre list
myBook.removeGenre("drama"); // removes "drama" genre from myBook
```

# class Library

## Library
Class Library has 2 different constructor functions.

**Constructor method `Library()`** assaigns a default value to all the class fields. 

**Constructor method `Library(string name, List<Member>? members = null, List<Book>? books = null)`**

Usage examples:
```cs
//example 1
Library library1 = new Library(); //library1 has a default name "my_library"
//example 2
Library library2 = new Library("Harvard_library"); //library2 get a user defined name "Harvard_library"

List<Member> membersList = {
	new Member("generatedId", "Jane", "Doe", "jdoe@mail.com"), 
	new Member("generatedId", "Harry", "Potter", "iamthewizard@mail.com", "123123123"); 
}
List<Book> booksList = {
	Book myBook = new Book("bookId1", "bookTitle", "author", new List<string>());
}
//example 3
Library library3 = new Library("local_library", membersList, booksList);
```

## addMember
Method **addMember** is type *bool*. It returns **true** if member was successfully added to the library list *Members* and **false** if member you are trying to add is aleredy in *Members* list.

Usage example:
```cs
Library myLibrary = new Library();
Member jane = new Member("generatedId", "Jane", "Doe", "jdoe@mail.com"); 

if (myLibrary.addMember(jane)){ 
	// member was successfully added to 'myLibrary'
}
```

## removeMember
Method **removeMember** is type *bool*. It returns **true** if member was successfully removed from library list *Members* and **false** if *Members* list does not contain a member you are trying to remove.

Usage example:
```cs
Library myLibrary = new Library();
Member jane = new Member("generatedId", "Jane", "Doe", "jdoe@mail.com"); 

if (myLibrary.addMember(jane)){ /* do something... */ }

if (myLibrary.removeMember(jane)){
	// member "jane" was removed from the list
}
```

## addBook
Method **addBook** is type *bool*. it returns **true** if book successfully added to the library list *Books* and **false** if book you are trying to add is aleredy in *Books* list.

Usage example:
```cs
Library myLibrary = new Library();
Book myBook = new Book("generatedId", "bookTitle", "author", new List<string>()); 

if (myLibrary.addBook(myBook)){ 
	// myBook was successfully added to 'myLibrary'
}
```

## removeBook
Method **removeBook** is type *bool*. It returns **true** if book was successfully removed from library list *Books* and **false** if *Books* list does not contain a book you are trying to remove.

Usage example:
```cs
Library myLibrary = new Library();
Book myBook = new Book("generatedId", "bookTitle", "author", new List<string>());

if (myLibrary.addBook(myBook)){ /* do something... */ }

if (myLibrary.removeBook(myBook)){
	// book "myBook" was removed from the list
}
```

## getMemberById
Method **getMemberById** takes *memberId* as argument and returns *Member* from list Members. If the list doesn't contain Member with the provided Id it returns **null**.

Usage example:
```cs
Library myLibrary = new Library();

Member? member = myLibrary.getMemberById("someId");
```

## getBookById
Method **getBookById** takes *bookId* as argument and returns *Book* from list Books. If the list doesn't contain Book with the provided Id it returns **null**.

Usage example:
```cs
Library myLibrary = new Library();

Book? book = myLibrary.getBookById("someId");
```

## lentBook
Method **lentBook** takes arguments *bookToLent* and *borrower*. It returns **true** if the book was successfully lent to *borrower*(member).
When used, default lent duration is 20 days (book is expected to be returned 20 days from date that is was borrowed). If you want to extend lent use [extendLent](#extendlent) method.

Usage example:
```cs
Library myLibrary = new Library();
Book myBook = new Book("generatedId", "bookTitle", "author", new List<string>());
Member jane = new Member("generatedId", "Jane", "Doe", "jdoe@mail.com");

if(myLibrary.lentBook(myBook, jane)) { 
	// book was successfully lent to a borrower
}
```

## extendLent
Method **extendLent** extends lent on a boom by number of days provided in method arguments.

Usage example:
```cs
Library myLibrary = new Library();
Book myBook = new Book("generatedId", "bookTitle", "author", new List<string>());
Member jane = new Member("generatedId", "Jane", "Doe", "jdoe@mail.com");

if(myLibrary.lentBook(myBook, jane)) { 
	myLibrary.extendLent(myBook, 30); // lent date was extended by additional 30 days
}
```

## returnBook
Method **returnBook** taks book marks it as returned.

Usage example:
```cs
Library myLibrary = new Library();
Book myBook = new Book("generatedId", "bookTitle", "author", new List<string>());

if(myLibrary.returnBook(myBook)) { 
	// myBook was successfully returned 
}
```

# class Date

## Date
**Constructor method `Date()`** is constructor that doesn't take any arguments. It sets date format to `dd-MMMM-yyyy`.

Usage example:
```cs
Date now = new Date(); //initialize the object with current time

string onlyDate = now.date; //return string date in format "dd-MMMM-yyyy"
string dateAndTime = now.dateTime; //return string date and time in format "dd-MMMM-yyyy HH:mm"
```

## addDays
Method **addDays** returns new date as string. Old date is provided as the first argument, second argument is whole number of days you want to be added to the old date.

Usage example:
```cs
Date now = new Date(); //initialize the object with current time

string newDate = now.addDays(now, 15); //adds 15 days to 'now'
```

# class Log

## writeLog
Method **writeLog** writes a log message to a file named *library.log* alogn with a specified date and time.

Usage example:
```cs
Date now = new Date();

Log.writeLog("some log message", now.dateTime); //you cold also use now.date or any other string
```

---

Keep in mind that this code may not be perfect, but it works. :)