using library_console.classes;
using System.Xml.Serialization;

class Program {
    static void Main(string[] args) {
        // hardcoded everything here FOR TESTING

        Library myLibrary = new Library("my_ibrary123");

        // Adding 10 books
        for (int i = 1; i <= 10; i++) {
            List<string> genres = new List<string> { $"Genre{i}" };
            Book book = new Book($"Book{i}", $"Title{i}", $"Author{i}", genres);
            myLibrary.addBook(book);
        }

        // Adding 15 members
        for (int i = 1; i <= 15; i++) {
            Member member = new Member($"Member{i}", $"First{i}", $"Last{i}", $"email{i}@example.com");
            myLibrary.addMember(member);
        }

        //removing member2 and book5 from library
        bool rmMem = myLibrary.removeMember(myLibrary.getMemberById("Member2"));
        bool rmBook = myLibrary.removeBook(myLibrary.getBookById("Book5"));

        //lenting book8 to member1 and book1 to member4
        bool lent8to1 = myLibrary.lentBook(myLibrary.getBookById("Book8"), myLibrary.getMemberById("Member1"));
        bool lent1to4 = myLibrary.lentBook(myLibrary.getBookById("Book1"), myLibrary.getMemberById("Member4"));

        //extending lent date
        myLibrary.extendLent(myLibrary.getBookById("Book8"), 10);


        //serialize library to xml file
        XmlSerializer xmlSer = new XmlSerializer(myLibrary.GetType());
        StreamWriter writer = new StreamWriter("library.xml");

        xmlSer.Serialize(writer, myLibrary);
    }
}
