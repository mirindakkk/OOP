using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Lab12
{
    class Program
    {
        static void Main(string[] args)
        {
            //Reflector reflector = new Reflector("Lab3.Book");
            //reflector.AboutClass();
            //reflector.PublicMethods();
            //reflector.Fields();
            //reflector.Interfaces();
            //reflector.Methods();
            //reflector.Runtimemethod("Met");

            //1
            Type myType = typeof(Reflector);

            Console.WriteLine(myType.ToString());
            Console.WriteLine(myType.Assembly.FullName);
            //2
            Reflector user = new Reflector("");
            Type myType2 = user.GetType();
            //3
            Type myType3 = Type.GetType("Lab12.Reflector", false, true);

            Console.WriteLine("Методы:");
            foreach (MethodInfo method in myType.GetMethods())
            {
                string modificator = "";
                if (method.IsStatic)
                    modificator += "static ";
                if (method.IsVirtual)
                    modificator += "virtual";
                Console.Write($"{modificator} {method.ReturnType.Name} {method.Name} (");
                //получаем все параметры
                ParameterInfo[] parameters = method.GetParameters();
                for (int i = 0; i < parameters.Length; i++)
                {
                    Console.Write($"{parameters[i].ParameterType.Name} {parameters[i].Name}");
                    if (i + 1 < parameters.Length) Console.Write(", ");
                }
                Console.WriteLine(")");
            }

            Console.WriteLine("Конструкторы:");
            foreach (ConstructorInfo ctor in myType.GetConstructors())
            {
                Console.Write(myType.Name + " (");
                // получаем параметры конструктора
                ParameterInfo[] parameters = ctor.GetParameters();
                for (int i = 0; i < parameters.Length; i++)
                {
                    Console.Write(parameters[i].ParameterType.Name + " " + parameters[i].Name);
                    if (i + 1 < parameters.Length) Console.Write(", ");
                }
                Console.WriteLine(")");
            }

            Console.WriteLine("Поля:");
            foreach (FieldInfo field in myType.GetFields())
            {
                Console.WriteLine($"{field.FieldType} {field.Name}");
            }

            Console.WriteLine("Свойства:");
            foreach (PropertyInfo prop in myType.GetProperties())
            {
                Console.WriteLine($"{prop.PropertyType} {prop.Name}");
            }

            Console.WriteLine("Реализованные интерфейсы:");
            foreach (Type i in myType.GetInterfaces())
            {
                Console.WriteLine(i.Name);
            }

            Console.ReadKey();
        }


        public class Reflector
        {
            public Type type;
            public Reflector(string type)
            {
                this.type = Type.GetType(type, false, true);
            }
            public void AboutClass()
            {
                using (FileStream fstream = new FileStream("class.txt", FileMode.Create))
                {
                    StreamWriter sw = new StreamWriter(fstream);
                    foreach (MemberInfo info in type.GetMembers())//GetMembers возвращает члены (свойства, методы, поля, события и т. д.) текущего объекта Type.
                    {
                        sw.WriteLine(info.DeclaringType + " - " + info.MemberType + " - " + info.Name + "\n");
                    }
                    sw.Close();
                }
            }
            public void PublicMethods()
            {
                using (FileStream fstream = new FileStream("methods.txt", FileMode.Create))
                {
                    StreamWriter sw = new StreamWriter(fstream);
                    foreach (MethodInfo method in type.GetMethods())
                    {
                        if (method.IsPublic)
                        {
                            sw.WriteLine(method.Name + "\n");//Массив байтов, содержащий результаты кодирования указанного набора символов.
                        }
                    }
                    sw.Close();
                }
            }
            public void Fields()
            {
                using (FileStream fstream = new FileStream("fields_properties.txt", FileMode.Create))
                {
                    StreamWriter sw = new StreamWriter(fstream);
                    foreach (FieldInfo field in type.GetFields())
                    {
                        sw.WriteLine(field.FieldType + " - " + field.Name + "\n");
                    }
                    foreach (PropertyInfo prorertie in type.GetProperties())
                    {
                        sw.WriteLine(prorertie.PropertyType + " - " + prorertie.Name + "\n");
                    }
                    sw.Close();
                }
            }
            public void Interfaces()
            {
                using (FileStream fstream = new FileStream("interfaces.txt", FileMode.Create))
                {
                    StreamWriter sw = new StreamWriter(fstream);
                    foreach (Type interfaces in type.GetInterfaces())
                    {
                        sw.WriteLine(interfaces.DeclaringType + " - " + interfaces.MemberType + " - " + interfaces.Name + "\n");
                    }
                    sw.Close();
                }
            }
            public void Methods()
            {
                MethodInfo[] methods = type.GetMethods();
                Console.Write("get in name of method: ");
                string name = Console.ReadLine();
                int count = 0;
                for (int i = 0; i < methods.Length; i++)
                {
                    if (methods[i].Name == name)
                    {
                        Console.WriteLine(methods[i].Name);
                        count++;
                    }
                }
                if (count == 0)
                {
                    Console.WriteLine("method not found");
                }
            }
            public void Runtimemethod(string method)
            {
                FileStream fstream = new FileStream("param.txt", FileMode.OpenOrCreate);
                StreamReader sr = new StreamReader(fstream);
                object obj1 = Activator.CreateInstance(type);
                string r;
                r = sr.ReadToEnd();
                object[] obj = new object[1];
                obj[0] = r;
                MethodInfo m = type.GetMethod(method);
                object result = m.Invoke(obj1, obj);
                Console.WriteLine(result);
            }
        }
    }
}
