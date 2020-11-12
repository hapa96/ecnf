# **C**# Summary

[toc]

# .Net Basics

![image-20201031115731307](C:\Users\pascal.hauser1\Documents\repos\ecnf\Summary\summary.assets\image-20201031115731307.png)

**Was versteht man unter „Managed Code“, was unter „Native Code“? Nennen Sie jeweils einige Vor- und Nachteile der beiden Ansätze.**

*Managed Code: Dieser Code wird von einem CLR (Common Language Runtime) in für maschinen ausführbaren Code übersetzt. Der Entwickler muss sich nicht um Memorymanagement kümmern und das Programm kann dank der VM plattformundabhängig laufen.*

*Native Code: Memory ist nicht "gemanaged". Heisst der Entwickler muss Memory selber allozieren und wenn nicht mehr gebraucht wieder freigeben.  Programm wird für eine bestimmte Plattform entwickelt. Gute Performance auf entsprechender Plattform*

**Was versteht man unter CLR:**

*(Common Language Runtime): Interoperability, Security, Garbage Collection, Versioning* ​*:arrow_right: Übersetzt den .Net Code für das entsprechende OS*

**Ein Ziel von .NET war unter anderem Language Interoperability. Was versteht man darunter? Wird das auch von Java unterstützt?**

*Language Interoperability macht es möglich, Code welcher in verschiedenen Programmiersprachen entwickelt wurde, gemeinsam zu nutzen. Die möglich macht die Common Intermediate Language (CIL). CLI wird auch in Java unterstützt.*

**Welche Bedingungen müssen .NET Programme erfüllen, damit diese „Language Interoperabel“ sind (dass also z.B. ein C#-Programm eine VB.NET-Assembly aufrufen kann).**

*Das Programm muss auf der Common Language Runtime laufen können. Dazu muss der Compiler das Programm in CIL -Format übersetzen können.*

**Base Class Libary:** *GUI, collections, threads, networking, reflection, XML, ....*

**Was ist ein Assembly?**
*Ist das Erzeugnis des kompilierten .Net Codes. Typischerweise DLL, exe*

![image-20201031120801920](C:\Users\pascal.hauser1\Documents\repos\ecnf\Summary\summary.assets\image-20201031120801920.png)

# C# Essentials

1. **Was ist der Hauptunterschied zwischen Structs und Klassen?**

   *Der Hauptunterschied besteht in dem Standardzugriff.  Struct ist public, class ist private. Structs sind Wertetypen, Klassen sind Referenztypen* 

2. **Welche Einschränkungen haben Structs gegenüber Klassen?**

   *Structs unterstützen keine Vererbung*

3. **Wann sollten Sie eher Structs, wann eher Klassen einsetzen?**

   *==Ein Struct ist passend, wenn die Wertetyp-Semantik gewünscht ist==. Beispiel numerische Typen, bei denen es natürlicher ist, eine Zuweisung einen Wert zu kopieren als eine Referenz. Da ein Struct ein Wertetyp ist, muss nicht bei jeder Instanzierung ein Objekt auf dem Heap erstellt werden*

4. **Was ist der Unterschied zwischen const und readonly? Existieren diese Konzepte in Java?**

   `readonly` Heisst, dass der Wert nach Initialisierung nicht mehr verändert werden kann. In java entspricht dies einer als `final` deklarierten Variable.
   `const` Ist eine zur Compilezeit definierte Variable und entspricht einer `static final ` Variable in Java.

6. **Was sind Named Arguments?**

```c#
public class Program {
 
   public static void Main() {
	   Print("sali", d: "ronweasley"); // d = named argument
       //Output = sali hello harrypotter ronweasley
   }
	
	static public void Print(string c, string a = "hello", string b = "harrypotter", string d = "ciao") {
		Console.WriteLine($"{c} {a} {b} {d}");
	}
}
```

7. **Was sind Optional Arguments?**

```c#
static public void Print(string c, string d = "ciao"); // d = optionales Argument
```

If a parameter is not supplied by caller, C# will use the default value.

8. **Value-Types können nicht mit null initialisiert werden?**  :arrow_right: ***richtig***

9. **Welche Möglichkeiten gibt es, um bestehende Klassen um eigenen Code zu ergänzen?**
   **Was sind die jeweiligen Vor- bzw. Nachteile?**

   Extension-Methods sind dazu da, um bestehene Methoden zu existierenden Typen hinzuzufügen. Dafür braucht es keine Rekompilation und der bestehende Typ wird nicht verändert.

   Von der Klasse erben und zusätzliche Methoden in der Subklasse implementieren. Source verändern schlecht möglich, da Klassen oftmals `sealed` sind.

10. **Was sind die Vor- und Nachteile von unsafe code?**

unsafe code = ich mache memory management selber

Höhere Performanz möglich, jedoch auch grössere Fehleranfälligkeit.

```c#
unsafe static void Main()  
{  
   fixed (char* value = "safe")  
   {  
      char* ptr = value;  
      while (*ptr != '\0')  
      {  
         Console.WriteLine(*ptr);  
         ++ptr;  
      }  
   } 
}
```

11. **Was sind anonyme Typen? Was sind deren Vor- und Nachteile?**

```c#
var v = new { Amount = 108, Message = "Hello" };  
```

Ein Vorteil: Inline definiert, sehr praktisch und kompakt.

Ein Nachteil: keine Wiederverwendung.

Verwendet v.A. beim Schreiben von LINQ-Expressions.

## Type System

![image-20201031121419652](C:\Users\pascal.hauser1\Documents\repos\ecnf\Summary\summary.assets\image-20201031121419652.png)

## Nullable Types

> Typen, die keinen definierten default wert besitzen. Diese können im Code den Wert `null`annehmen, was einige Konsequenzen mit sich zieht. Nullable Types sind value types (als struct implementiert). 

**`?` makes value-types nullable**

 ​ `int a = null` :x: 

 `int? b = null` :heavy_check_mark: 

**`??` Null-coalescing operator** Is a binary operator that is part of a conditional expression

```c#
class Person
{
    public string Name {get; set;}
}
var p = new Person();
//so far
string name = (p.Name != null) ? p.Name : "Unknown";
//more compact using null coalescing operator
string name = p.Name ?? "Unknown"; // Ist p == null -> "Unknow" ; p != null -> p.Name
//Test if p is null included
Person p1 = new Person();
string name = p1?.Name ?? "Unknown"; //Wenn (p1 || Name) == null ~> "Unknown"
```

```c#
//Combine with nullable types
int? i = 3;
int x = i ?? 0; //Wenn i == null -> cast nullable int zu int mit Wert 0
int y??= 0; //Cast -> Wenn y == null = y = 0
```

![image-20201103065611276](C:\Users\pascal.hauser1\Documents\repos\ecnf\Summary\summary.assets\image-20201103065611276.png)

## Operator Overloading

> Operator overloading allows you to define `static` custom opertor implementations for various operators.

![image-20201103065822198](C:\Users\pascal.hauser1\Documents\repos\ecnf\Summary\summary.assets\image-20201103065822198.png)

``` C#
class Stock{
    string currentPrice = {get; set;}
    public Stock (float price){
        this.currentPrice = price;
    }
    
   //Operator Overloading
    public static Stock operator+ (Stock s1, Stock s2)
    {
        return new Stock(s1.currentPrice + s2.currentPrice);
    }
    
    public static Stock operator- (Stock s1, Stock s2)
    {
        return new Stock(s1.currentPrice - s2.currentPrice);
    }
}   
```

![image-20201103072720283](C:\Users\pascal.hauser1\Documents\repos\ecnf\Summary\summary.assets\image-20201103072720283.png)

## Extension Methods

> Extensionmethods ermöglichen es, bestehende Typen durch neue Methoden zu erweitern., ohne die Definition des Ursprungstypenverändern zu müssen. 

```c#
// Adding a method to the string class
public static class StringExtensions // Postfix = Extensions  ~> Common Extension
{
    public static bool IsCapitalized(this string s)
    {
        if (string.IsNullOrEpty (s)) return false;
        return char.IsUpper(s[0]);
    }
}
```

## yield

> Method that incrementally computes and returns sequence of values

* Berechnung von grösseren Listen ==performant & Memory schonend== 
* yield kann nur mit IEnumerable

```C#
public static IEnumerable<int> GenerateNumbers(int num)
{
    for (var i = 0; i<num; i++)
        yield return i; 
}
```

## Boxing& Unboxing

> Object is the Mother of all Types

**Boxing: ** Converting a Value Type into a reference Type, Wraps up the value of i1 from the stack in a heap object

![image-20201031121702529](C:\Users\pascal.hauser1\Documents\repos\ecnf\Summary\summary.assets\image-20201031121702529.png)

````c#
int i1 = 3; // Stack
object obj = i1 ; //Heap
````

**Unboxing:** Converting a reference Type into a Value Type. Unwraps the Value again

```C#
int i2 = (int) obj;
```

**Generelle Regel:** Value Type = Stack; Reference Type= Heap :arrow_right: Schlussendlich Sache des VM Entwicklers

## Classes

```C#
//Declaration
class Data
{
    string f;
    pulbic string FileName;
    {
        set{f = value;}
        get{return f;}
    }
}
//Usage
var d = new Data();
d.FileName = "myFile.txt" //Calls setFileName("myyFile.txt")
var s = d.FileName; //Calls getFileName()
```

### Automatic properties

```c#
class Data
{
    public string CreateDate {get; set;} = DateTime.Now; //Compiler generates a private field internally
    public string FilePath {get; private set;} // get and set can have different modifiers
    public List<City> CitiesList { get { return cities; } }
}
```

### Parameters

==Default passing: By-Value==

By-Reference modifier `ref`

```c#
void PEx(int i, ref int ref_i, out int out_i){...}
```

### Indexer

```c#
//Implementation
class Portfolio
{
    Stock[] stocks;
    public Stock this[int index] //Indexer implementation
    {
        get{return this.stocks[index];}
        set{this.stocks[index] = value;}
    }
    // ....
//Usage
    Console.WriteLine(portfolio[i].Symbol)
```

### Abstract Classes

![image-20201031130722890](C:\Users\pascal.hauser1\Documents\repos\ecnf\Summary\summary.assets\image-20201031130722890.png)

### Interfaces

![image-20201031130804270](C:\Users\pascal.hauser1\Documents\repos\ecnf\Summary\summary.assets\image-20201031130804270.png)

### Arrays

![image-20201031130912570](C:\Users\pascal.hauser1\Documents\repos\ecnf\Summary\summary.assets\image-20201031130912570.png)

### I/O

#### I/O- Working with the file system

![image-20201031131135803](C:\Users\pascal.hauser1\Documents\repos\ecnf\Summary\summary.assets\image-20201031131135803.png)

#### I/O- TextReader/ Writer

![image-20201031131214933](C:\Users\pascal.hauser1\Documents\repos\ecnf\Summary\summary.assets\image-20201031131214933.png)

```C#
using (StreamReader sr = new StreamReader(path))
            {
                while (sr.Peek() > -1) //next character to be read, or -1 = End of File
                {
                    Console.WriteLine(sr.ReadLine());
                }
            }
```

### Inheritance

> Classes can only inherit from a single base class, but can implement multiple interfaces
>
> Classes can only inherit from classes, not from structs

```C#
class B : A //subclass (inherits from A, extends A)
{...}
```

**Demonstrieren Sie den Einsatz und die Effekte von new, override, virtual**

`new` Teilt dem Compiler mit, dass doppelte Member kein versehen ist, sondern gewollt. (Unterdrückt Compiler-Warnung)

`virtual` Methoden können von Subklassen überschrieben werden. ==Methoden, welche überschrieben werden sollen, *müssen* in c# als `virtual` deklariert werden.==

`override` Kennzeichnet eine Methode, welche eine `virtual` Methode überschreibt. Dies geschieht in Subklassen.

![image-20201031134359790](C:\Users\pascal.hauser1\Documents\repos\ecnf\Summary\summary.assets\image-20201031134359790.png)

![image-20201031141108346](C:\Users\pascal.hauser1\Documents\repos\ecnf\Summary\summary.assets\image-20201031141108346.png)

# Delegates

**Wann hat ein Delegate/Event den Wert null?**

*Wenn keiner sich darauf angemeldet hat. Deshalb muss immer geprüft werden, ob das delegate null ist. (`delegate?.Invoke(args)`)*

**Was passiert, wenn man einen Event mit dem Wert null ausführt?**

*C# wirft eine NullReferenceException (`System.NullReferenceException`)*

**Was geschieht, wenn Exceptions in einem Multicast Delegate auftreten?**

*Die Kette von Aufrufen wird am Punkt der Exception unterbrochen und nachfolgende delegates werden nicht aufgerufen.*

*Ein `delegate` ist eine Methodenrefenz. Es verbindet einen Aufrufer einer Methode zur Laufzeit mit seiner Zielmethode.* 

![image-20201030070614294](C:\Users\pascal.hauser1\Documents\repos\ecnf\Summary\summary.assets\image-20201030070614294.png)

### Wann sollte man delegates verwenden?

Use delegates when you would use a ==single method class== otherwise

* Coparers
* Event-Handling
* Mapping
* Callbacks
* ...

### Characteristics of delegates

* Delegates are object-oriented, type-safe `function pointers`
* Methods may be static or non-static
* Delegate implementations must match the delegate type :arrow_right: fulfil the contract
* A Delegate stores methods, but not parameter values
* Delegates are immutable
* Delegates are reference types
* Delegates are multicast-able

:exclamation: Don't use return values :arrow_right: If the multicast delegate returns a value, the value of the last call is returned.

### How to use Delegates

```C#
delegate void AMethodWithAStringParameter(string param1); // Typ
AMethodWithAStringParameter a; // Variable
void SayHello(string name) // Konkrete Implementation des delegates
{
	Console.WriteLine($"Hello {name}");
}
a = SayHello;
a("Kurt"); // Hello Kurt
```



### Multicast Delegate Example

Suppose that you wrote a method that took a long time to execute. That method could regularly report progress to its caller by invoking a delegate. In this example, the HardWork method has a ProgressReporter delegate parameter, which it invokes to indicate progress:

```c#
public delegate void ProgressReporter (int percentComplete); //define Delegate

public class Util 
{ 
	public static void HardWork (ProgressReporter p)
	{
		for(int i=0;i<10;i++)
		{
			p (i*10);	//Invoke delegate
			System.Threading.Thread.Sleep(100);	//Simulate hard work
		}
	}
}
```

To monitor progress, the Main method creates a multicast delegate instance p, such that progress is monitored by two independent methods:

```c#
class Test
{
    static void Main()
    {
        ProgressReporter p = WriteProgressToConsole;
        p += WriteProgressToFile; //
        Util.HardWork (p);
    }
    //Delegates:
    static void WriteProgressToConsole (int percentComplete)
        => Console.WriteLine (percentComplete);
    
    static void WriteProgressToFile (int percentComplete)
        => System.IO.File.WriteAllText("progress.txt",
										percentComplete.ToString());
    
}
```

### Events

The `event`Keyword is an ==access limiting modifier== for delegates.

Limits the access of a delegate from outside:

* Only the declating class can invoke it
* Other classes may append/ remove the ebent handlers, but not replace the whole list

When using delegates, two emergent roles commonly appear: `broadcaster` and `subscriber` 

The broadcaster is a type that contains a delegate field. The ==broadcaster decides when to broadcast, by invoking the delegate== . The subscribers are the method target recipients. A subscriber decides when to start and stop listening by calling += and -= on the broadcaster's delegate. ==A subscriber does not know about, or interfere with, other subscribers.== 

#### Standard Event Pattern

EventArgs is a base Class for conveying information for an event. 

For reusability, the EventArgs subclass is named according to the information it contains (rather than the event for which it will be
used). It typically exposes data as properties or as read-only fields.

#### Rules Event Pattern

With an `EventArgs` subclass in place, the next step is to choose or define a delegate for the event.

* It must have a `void` return type
* It must accept two arguments: the first of type `object`, and the second a subclass of `EventArgs`. The first argument indicates theevent broadcaster, and the second argument contains the extra information to convey.
* Its name must end with `EventHandler` 

#### Event Example

StockPriceIncreased Event. Das Event soll nur ausgelöst werden, wenn siech der Preis geändert hat.

```C#
public class Stock{
    float currentPrice = 0.0f;
    public delegate void PriceChangeHandler(object sender, PriceChangeEventArgs args); //Typ
    public event PriceChangeHandler StockPriceIncreased; //Variable
        
    public void ChangeStockPrice(float newPrice)
    {
        if(currentPrice != new Price)
        {
            StockPriceIncreased?.Invoke(this, new PriceChangeEventArgs(newPrice));
        }
        this.currentPrice = newPrice;
    }
    //Defining ChangeEventArgs according to convention
    public class PriceChangeEventArgs : EventArgs
    {
        float NewPrice{get;set;}
        public PriceChnangeEventArgs (float p)
        {
            NewPrice = p;
        }
    }
}
```

### Predefined delegate Types

#### Action delegate

> Generic delegate type for methods with any parameters and no return value

```C#
delegate void Action();
delegate void Action<in T1> (T1 arg)
...
```

##### Example:

```C#
private static void ActionDelegateExample()
{
    Action<string> act = ShowMessage;
    act("C# language");
}
private static void ShowMessage(string message)
{
    Console.WriteLine(message);
}
```

Anwendunsfall: Mausklicks, GUI-Events im Allgemeinen, Methoden ohne return Type.

#### Func delegates

> Generic delegate type for methods with any parameters and a return value

```C#
delegate TResult Func<out TResult> ();
delegate TResult Func<in T1, out TResult>(T1 arg);
...
```

##### Example:

```C#
public void FuncDelegateExample()
{
    Func<string, string> convertMethod = UppercaseString;
    Console.WriteLine(convertMethod("Dakota")); //DAKOTA
}
private string UppercaseString(string inputString)
{
    return inputString.ToUpper();
}
```

Anwendungsfall: Generische Methoden mit *n* Parametern und einem Rückgabetyp. Zum Beispiel mathematische Funktionen oder Verarbeitung von Daten.

#### Predicate delegates

> Generic delegate type for methods with a single parameter and a return type bool

##### Example:

```C#
class List<T>{
    List<T> FindAll(Predicate<T> match);
    t Find(Predicate<T> match);
    //.....
}
bool GreaterThan10(int x){
    return x > 10;
}
void Main(){
    var listOfNumbers= new Int[] {1,2,35,3,11}.ToList();
    var firstMatch = listOfNumbers.Find(GreaterThan10);
}
```

Anwendungsfall: Vergleichsevaluation. Haben Rückgabetyp `bool`. Sortieren von Listen bzw. IEnumerbales

##### Example Routeplaner:

Such-Funktion, die eine Stadt anhand des Namens findet und das entsprechende City-Objekt zurückgibt.

```C#
//To search a City by his name
public City this[string cityName]
{
	get
    {
    	// define Delegate for Comparison
        Predicate<City> compareName = delegate (City c) { return c.Name.Equals(cityName,         													StringComparison.InvariantCultureIgnoreCase); };
        
        if (cityName == null)
        {
            throw new ArgumentNullException();
        }
        else
        {
            var city = (cities.Find(compareName));
            if (city != null) return city;
            else
            {
                throw new KeyNotFoundException();
            }
            //....
```



# LINQ

**Was ist der Unterschied zwischen der „query syntax“ und der „method syntax“? Was hat dies für Auswirkungen auf die Ausführung der Queries?**

*Comprehension Queries folgen einer SQL ähnlichen Syntax, Lambda-Queries folgen dem Object-Model unde verwenden Extension Methodes*

*Method Syntax Queries stellt eine grössere Mengen an Operatiren zu Verfügung als die Comprehensive Query*

*Keine Auswirkungen. Comprehension queries werden vom Compiler in Lambda Ausdrücke übersetzt.*

**Was versteht man unter Closure? Was ist dadurch möglich? Was sind unerwünschte**
**Seiteneffekte?**

Closure findet in Lambda-ausdrücken statt. Das Definierte Lambda merkt sich den Kontext, in welchem es Erzeugt wurde. So werden sich auch Variablen gemerkt. Somit wird der Scope der Variable vergrössert, was zur Folge haben kann, dass bei der effektiven Ausführung des Lambdas (deferred execution) die Variablen nicht mehr die gleichen Werte besitzen und so ein anders/falsches Resultat herauskommt.

**Was ist deferred execution? Weshalb wurde LINQ so implementiert? Was sind Vorteile?**
**Was sind unerwünschte Seiteneffekte?**

Deferred execution ist, wenn der LINQ Ausdruck zu einem späteren Zeitpunkt ausgeführt wird, als dass er definiert ist. Das heisst, dass mit der Ausführung einer LINQ-Expression gewartet wird, bis dass eine Ausführung zwingend nötig wird. Linq wurde so implementiert, dass man komplexe und rechenintensive Statements machen kann, ohne diese direkt auszuführen. Somit kann zu gegebener Zeit zum Beispiel eine Iteration eines Loops durchgeführt werden, was wenig Performance kostet. Ein Nachteil davon ist, dass die Ausführung explizit erzwungen werden muss.

**Was sind Vorteile von LINQ?** 

LINQ ermöglicht es, ähnlich wie Java mit den Streams, sehr kompakte, strukturierte, typ-sichere Abfragen für lokale Objektcollections und Datenquelle auf anderen Rechnern zu schreiben.

**Über welchen Datentyp geben LINQ-Abfragemethoden ihre Resultate am besten zurück? Was sind die Vor- und Nachteile von List \<T>, IEnumerable \<T> oder T[]?**

* Bei List\<T\> hat man den Vorteil, dass alle List Operationen verfügbar sind. Zum Beispiel kann man direkt über die Liste mit `for-each` iterieren. Nachteil: LINQ-Expression wird sofort evaluiert, da wieder ein Liste erzeugt werden muss. 

* IEnumerable\<T\> : Default Return Type bei LINQ :arrow_right:  deferred evaluation

  Expression kann direkt weiter spezifiziert und modifiziert werden ( wie eine Pipeline)

* T[]: Nachteil: ToArray alloziert mehr Speicher als Vergleichsweise ToList.

**Was sind Vor- und Nachteile von Local Queries gegenüber Remote Queries?**

* Local Query:
  * Vorteil: Keine Abhängigkeit durch Datenbank (tendenziell weniger remote Queries)
  * Nachteil: Höherer Netzwerktraffic aufgrund von grösseren Datenmengen, welche übertragen werden müssen.
* Remote Query:
  * Vorteil: Datenbank ist wesentlich effizienter im filtern der Abfrage ( DatenbankIndex, Keys,etc.)
  * Nachteil: Wenn Query verändert werden, müssend diese zur Laufzeit neu kompiliert werden. 

**Wie kann man die Ausführung einer LINQ-Abfrage als Local oder Remote Query forcieren?**

Man muss mittels immediate query evaluation das Linq querry zu einer Abschliessenden Aktion forcieren.

> The ToList<TSource>(IEnumerable<TSource>) method forces immediate query evaluation and returns a List<T> that contains the query results. You can append this method to your query in order to obtain a cached copy of the query results.

**Welche LINQ-Methoden werden verzögert (deferred) ausgeführt, welche sofort?**

***Deferred Execution:***

*Where, Take, TakeWhile, Skip, SkipWhile, Distinct, Select, SelectMany, Join, GroupJoin, Zip, OrderBy, OrderByDescending, ThenBy, ThenByDescending, Reverse, GroupBy, Concat, Union, Intersect, Except, OfType, Cast*

***Immediatly Execution:***

*ToArray, ToList, ToDictionary, ToLookup, AsEnumerable, AsQueryable, Aggregate, Average, Count, LongCount, Sum, Max, Min*

**Was sind «Expression Trees»?**

![image-20201102062055754](C:\Users\pascal.hauser1\Documents\repos\ecnf\Summary\summary.assets\image-20201102062055754.png)

> In LINQ, expression trees are used to represent structured queries that target sources of data that implement IQueryable<T>. For example, the LINQ provider implements the IQueryable<T> interface for querying relational data stores. The C# compiler compiles queries that target such data sources into code that builds an expression tree at runtime. The query provider can then traverse the expression tree data structure and translate it into a query language appropriate for the data source.

## Examples LINQ

```C#
// Eine Person in der Liste heisst Pascal
var sameName = persons.Any(x => x.FirstName == "Pascal");

//Zählen Sie die Anzahl Autos (->Using SelectMany)
var allCars = persons.SelectMany(x => x.Cars).Count();

//Überprüfen Sie, ob alle Personen mindestens ein Auto besitzen (All).
var atLeastOneCar = persons.All(x => x.Cars.Any());

//Geben Sie alle von Managern gefahrene Automarken auf die Konsole aus (OfType, SelectMany).
var managerCars = persons.OfType<Manager>().SelectMany(p => p.Cars).Select(c => c.Model).Distinct();
 
//Geben Sie den ersten Buchstaben aller Vornamen aus, ohne einen Buchstaben doppelt aufzulisten
var firstLetterOfSurname = persons.Select(x => x.FirstName[0]).Distinct();

//Geben Sie alle Personen aus, sortiert nach Vornamen, Nachnamen und Anzahl Autos.
var sorted = persons.OrderBy(x => x.FirstName).ThenBy(x => x.LastName).ThenBy(x => x.Cars.Count());

//Gruppieren Sie die Personen mit Hilfe der LINQ-Methode GroupBy nach Vornamen und schreiben Sie auf die Konsole, wie oft welcher Vornamen vorkommt. Sortieren Sie diese Liste alphabetisch nach Vornamen (OrderBy).
var groupedPerson = persons.GroupBy(p => p.FirstName).OrderBy(p => p.Key);
foreach (var personGroup in groupedPerson)
{
    Console.WriteLine($"{personGroup.Key} has count: {personGroup.Count()} members.");
}
//Bestimmen Sie die Nachnamen aller Personen, die mit Vornamen „Bill“ heissen (Where). Bestimmen Sie den alphabetisch ersten Nachnamen dieser Personen (First und OrderBy).
var desiredPerson = persons.Where(x => x.FirstName == "Bill").OrderBy(x => x.LastName).First().LastName);

// Berechnen Sie, wie viele Autos eine Person durchschnittlich besitzt (Average, Count)
var averageCar = persons.Average(p => p.Cars.Count());

//Schreiben Sie die häufigste Auto-Farbe auf die Konsole.
var populareColor = persons.SelectMany(c => c.Cars)
                            .GroupBy(c => c.Color)
                            .OrderByDescending(c => c.Count())
                            .First();
//Implementieren Sie eine eigene Kopie der LINQ-Methode Select als AwesomeSelect neu. Diese Extension-Method soll auf beliebige IEnumerable<T> angewendet werden können und eine neue Folge produzieren, die alle Elemente in transformierter Form enthält. Die Transformation soll als Lambda-Ausdruck übergeben werden können. Verwenden Sie in Ihrer Implementation yield.
int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }; 
var result = numbers.AwesomeSelect(n => (int)(n * Math.PI)).ToArray();

//Extension:
 public static IEnumerable<T> AwesomeSelect<T>(this IEnumerable<T> input, Func<T, T> func )
        {
            foreach (var item in input)
            {
                yield return func(item);
            }
        }
```

## LINQ with Query Syntax

```C#
// Eine Person in der Liste heisst Pascal
var myNameExists = (from person in persons
                    where (person.FirstName == "Pascal")
                    select person).Any();

//Zählen Sie die Anzahl Autos in der Liste 
var cars = (from person in persons from car in person.Cars select car).Count() ;
```

