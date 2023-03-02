using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleEvents
{
    public delegate void FinishDelegate();
    public class ParSummator
    {
        private int _maxVal;
        private object locker = new ();

        public long? Result
        {
            get;
            set;
        }

        public event FinishDelegate Finish;

        public ParSummator(int maxVal)
        {
            _maxVal = maxVal;
        }

        public void Sum()
        {
            var threadCount = 8;
            var counter = 0;
            Result = 0;
            for (int tn = 0; tn < threadCount; tn++)
            {
                new Thread(tn =>
                {
                    var s = 0L;
                    for (int i = 1 + (int)tn; i <= _maxVal; i+=threadCount)
                    {
                        s += i;
                    }

                    lock (locker)
                    {
                        Result += s;
                        counter++;
                        if (counter == threadCount && Finish!=null) Finish();
                    }
                }).Start(tn);
            }
        }
    }
}
