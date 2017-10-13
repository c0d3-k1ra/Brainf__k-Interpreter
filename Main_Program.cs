using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brainf__k_Interpreter
{
    class Main_Program
    {
        static void Main(string[] args)
        {
            bool error = false;
            if(args.Length == 0)
            {
                Brainf__k.print_help();
            }
            else if(args.Length == 1)
            {
                Brainf__k bf_interpreter = new Brainf__k();
                string c_arg = args[0];
                
                if(c_arg[0] == '-' && c_arg.Length == 2)
                {
                    switch(c_arg[1])
                    {
                        case 'h':
                            {
                                Brainf__k.print_help();
                                break;
                            }
                        case 'v':
                            {
                                Brainf__k.print_version();
                                break;
                            }
                        case 'k':
                            {
                                Console.WriteLine("Enter Code Below:");
                                string src = Console.In.ReadToEnd();
                                bf_interpreter.interpret(src);
                                break;
                            }
                        default:
                            {
                                error = true;
                                break;
                            }

                    }
                }
                else if (c_arg[0] == '-' && c_arg.Length != 2)
                {
                    error = true;
                }
                else
                {
                    if (File.Exists(c_arg))
                    {
                        bf_interpreter.interpret(File.ReadAllText(c_arg));
                    }
                    else
                    {
                        Console.WriteLine("File Open Error: " + c_arg);
                        error = true;
                    }

                }
            }
            else
            {
                error = true;
            }
            if(error)
            {
                Console.WriteLine("Bad Command");
                Brainf__k.print_help();
            }
        }
    }
}
