using System;
using System.Collections.Generic;

namespace library_console.classes
{
    public class Book {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public List<string> Genre { get; set; } //todo - create enum class of genres
        public bool IsBorrowed { get; set; }
        public string? Borrower { get; set; }
        public string? DateLent { get; set; }
        public string? DateLentUntil { get; set; }
        public string? DateReturned { get; set; }

        public Book() {
            Id = string.Empty;
            Title = string.Empty;
            Author = string.Empty;
            Genre = new List<string>();
            IsBorrowed = false;
            Borrower = null;
            DateLent = null;
            DateLentUntil = null;
            DateReturned = null;
        }
        public Book(string id, string title, string author, List<string> genre) {
            Id = id;
            Title = title;
            Author = author;
            Genre = genre;
            IsBorrowed = false;
            Borrower = null;
            DateLent = null;
            DateLentUntil = null;
            DateReturned = null;
        }
        public void addGenre(string genre) {
            //only add genre if it's not already in the list
            if (!Genre.Contains(genre)) {
                Genre.Add(genre);
            }
        }
        public void removeGenre(string genre) {
            if (Genre.Contains(genre)) {
                Genre.Remove(genre);
            }
        }
    }
}
