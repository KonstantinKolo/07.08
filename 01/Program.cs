using System;

namespace _01 {
    class Program {
        static void Main(string[] args) {
            CircularQueue<int> queue = new CircularQueue<int>();

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Dequeue();
            queue.Enqueue(8);
            queue.Enqueue(9);
            queue.Enqueue(10);
            queue.Enqueue(8);
            queue.Dequeue();

            int[] arr = queue.ToArray();
            Console.WriteLine(string.Join(' ',arr));
            Console.WriteLine(queue.Count);
        }
    }
    public class CircularQueue<T> {
        private T[] array;
        private int count;
        private int headIndex;
        private int tailIndex;
        private const int DefaultCapacity = 4;


        public int Count {
            get { return count; }
            private set { count = value; }
        }

        public CircularQueue() {
            array = new T[DefaultCapacity];
            count = 0;
        }

        public void Enqueue(T element) {
            CheckIfFull();
            if (count == 0) {
                this.array[0] = element;
                this.headIndex = 0;
                this.tailIndex = 0;
            }
            else  if (this.tailIndex == this.array.Length - 1) {
                this.array[0] = element;
                this.tailIndex = 0;
            }
            else{
                this.array[tailIndex + 1] = element;
                this.tailIndex++;
            }

            this.count++;
        }
        public T Dequeue() {
            T element = this.array[this.headIndex];
            this.array[this.headIndex] = default;
            if(count == 1) {
                this.headIndex = default;
                this.tailIndex = default;
            }
            else if(this.headIndex == this.array.Length - 1) {
                this.headIndex = 0;
            }
            else {
                this.headIndex++;
            }

            this.count--;
            return element;
        }
        public T[] ToArray() {
            T[] newArray = new T[this.count];
            CopyElements(newArray);
            return newArray;
        }

        private void CheckIfFull() {
            if (this.count == this.array.Length) {
                T[] newArray = new T[this.array.Length * 2];
                CopyElements(newArray);
                this.array = newArray;
            } 
        }
        private void CopyElements(T[] newArray) {
            int helper = 0;
            if (this.headIndex < this.tailIndex) {
                for (int i = this.headIndex; i <= this.tailIndex; i++) {
                    newArray[helper] = this.array[i];
                    helper++;
                }
            }
            else {
                for (int i = this.headIndex; i < this.array.Length; i++) {
                    newArray[helper] = this.array[i];
                    helper++;
                }
                for (int i = 0; i <= this.tailIndex; i++) {
                    newArray[helper] = this.array[i];
                    helper++;
                }
            }
            this.headIndex = 0;
            this.tailIndex = helper - 1;
        }
    }
}
