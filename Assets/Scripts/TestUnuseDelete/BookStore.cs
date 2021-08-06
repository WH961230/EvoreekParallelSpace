using System.Threading;
using UnityEngine;

namespace DefaultNamespace {
    public class BookStore {
        public delegate void Callback(string s);
        public event Callback NotifyNewbook;
        private const int SleepTime = 1000;

        private string BookState { get; set; }
        private readonly string[] newBooks = new []{"《鲁迅》", "《大学》", "《新青年》", "《毛选》", "《易经》", "《青年文摘》"};
        public void Go() {
            var thread = new Thread(Run);
            thread.Start();
        }

        private void Run() {
            foreach (var newBook in newBooks) {
                Debug.Log("书店新书 : " + newBook);
                BookState = newBook;
                NotifyNewbook?.Invoke(BookState);
                Thread.Sleep(SleepTime);
            }
        }
    }
}