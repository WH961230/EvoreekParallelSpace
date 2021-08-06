using UnityEngine;

namespace DefaultNamespace {
    internal class User {
        private BookStore bookStore;
        private string state;
        private readonly string name;
        
        public User(BookStore bookStore, string name) {
            this.bookStore = bookStore;
            this.name = name;
            bookStore.NotifyNewbook += Update;
        }

        private void Update(string BookState) {
            state = BookState;
            Debug.Log(name + ":" + state);
        }
    }
}