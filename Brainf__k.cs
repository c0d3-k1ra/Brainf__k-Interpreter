using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brainf__k_Interpreter
{
    class Brainf__k
    {
        private static string VERSION = "v0.0.1";
        private static readonly int BUFFERSIZE = ushort.MaxValue;
        private int[] buffer = new int[BUFFERSIZE];
        private int pointer { get; set; }
        private int get_value_at_pointer()
        {
            return this.buffer[this.pointer];
        }
        private void clear()
        {
            Array.Clear(this.buffer, 0, this.buffer.Length);
        }
        private void increment_pointer()
        {
            this.pointer++;
            if (this.pointer >= BUFFERSIZE)
            {
                this.pointer = 0;
            }

        }
        private void decrement_pointer()
        {
            this.pointer--;
            if (this.pointer < 0)
            {
                this.pointer = BUFFERSIZE - 1;
            }

        }
        private void increment_value()
        {
            this.buffer[this.pointer]++;
        }
        private void decrement_value()
        {
            this.buffer[this.pointer]--;
        }
        private void putchar()
        {
            Console.Write((char)this.buffer[this.pointer]);
        }
        private void getchar()
        {
            ConsoleKeyInfo key = Console.ReadKey(true);
            this.buffer[this.pointer] = (int)key.KeyChar;
        }
        
        public Brainf__k()
        {
            this.pointer = 0;
            this.clear();
        }
        public static void print_version()
        {
            Console.WriteLine("BrainFuck Interpreter " + VERSION);
            Console.WriteLine("By Amit Upadhyay");
        }
        public static void print_help()
        {

            Console.WriteLine("BrainFuck Interpreter " + VERSION);
            Console.WriteLine("By Amit Upadhyay");
            Console.WriteLine("Parameter: -h: Help");
            Console.WriteLine("Parameter: -k: Input via keyboard");
            Console.WriteLine("Parameter: -v: Version");
            Console.WriteLine("Parameter: FileName: *.bf program");

        }
        public void interpret(string program)
        {
            int bound = program.Length;
            
            int iterator = 0;
            while(iterator < bound)
            {
                switch(program[iterator])
                {
                    case '>':
                        {
                            
                            increment_pointer();
                            
                            break;
                        }
                    case '<':
                        {
                            decrement_pointer();
                            break;
                        }
                    case '+':
                        {
                            increment_value();
                            break;
                        }
                    case '-':
                        {
                            decrement_value();
                            break;
                        }
                    case '.':
                        {
                            putchar();
                            break;
                        }
                    case ',':
                        {
                            getchar();
                            break;
                        }
                    case '[':
                        {
                            if(get_value_at_pointer() == 0)
                            {
                                int loopnumber = 1;
                                while(loopnumber > 0)
                                {
                                    iterator++;
                                    char current = program[iterator];
                                    if(current == '[')
                                    {
                                        loopnumber++;
                                    }
                                    else if(current == ']')
                                    {
                                        loopnumber--;
                                    }
                                }
                            }
                            break;
                        }
                    case ']':
                        {
                            int loopnumber = 1;
                            while (loopnumber > 0)
                                {
                                    iterator--;
                                    char current = program[iterator];
                                    if (current == '[')
                                    {
                                        loopnumber--;
                                    }
                                    else if (current == ']')
                                    {
                                        loopnumber++;
                                    }
                                }
                            
                            iterator--;
                            break;
                        }
                    default:
                        {
                            break;
                        }

                }
                iterator++;
            }
        }
        
    }
}
