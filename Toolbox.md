# C# 8.0 .Net Core

[Toc]

## Basics .Net

![](C:\Users\pascal.hauser1\Documents\repos\ecnf\pictures\what-is-dot-net.PNG) 

*  **.Net** is cross platform :arrow_right: runs on Windows, OS X, Linux, Android, IOS

* Embeddable





## Basics C#

### Coding Conventions

[Coding Conventions](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/inside-a-program/coding-conventions) 

**Comparison to Java**

```C#
using System;			//import in Java
namespace HelloWorld	//package in Java
{
    class Hello
    {
        private string name
            private void Greet() 	//Methodes with Capital Letters
        {
            Console.WriteLine($"Hello {name}");	//String Interpolation
        }
        public static void Main(string[] args)
        {
            var me = new Hello();
            me.name = args[0];
            me.Greet();
        }
    }
}
```



### Strings

#### String-Interpolation

With the help of the $-Sign you can bind Code directly to a String generation.

```c#
string s = $"My Name is : {Pascal.Firstname} {Pascal.Surname} // My Name is Pascal Hauser
```



