# C#

[toc]

## Delegates

Ein `delegate` ist eine Methodenrefenz. Es verbindet einen Aufrufer einer Methode zur Laufzeit mit seiner Zielmethode. 

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

```C#
using System;
//Define the Event Args
public class PriceChangedEventArgs : EventArgs
{
    public readonly decimal LastPrice;
    public readonly decimal NewPrice;
    
    public PriceChangedEventArgs (decimal lastPrice, decimal newPrice)
    {
        LastPrice = lastPrice; NewPrice = newPrice;
    }
}
public class Stock
{
    string symbol;
    decimal price;
    
    public Stock(string symbol) => this.symbol = symbol;
    public event EventHandler<PriceChangedEventArgs> PriceChanged;
    
    //Fire Event
    protected virtual void OnPriceChanged(PriceChangedEventArgs e)
    {
        PriceChanged?.Invoke (this, e); //(Object, PriceChangedEventArgs)
    }
    
    public decimal Price
    {
        get => price;
        set{
            if (price == value) return;
            decimal oldPrice = price;
            price = value;
            //Fire Event, if a new Value was set
            OnPriceChanged (new PriceChangedEventArgs (oldPrice, price));
        }
    }
}
//Test Method
class Test
{
    static void Main()
    {
        Stock stock = new Stock("THPW");
        stock.Price = 27.1M;
        // Regster with the PriceChanged event
        stock.PriceChnaged += stock_PriceChanged;
        stock.Price = 31M;
    }
    static void stock_PriceChanged( object sender, PriceChangedEventArgs e)
    {
		if((e.NewPrice-e.LastPrice)/e.LastPrice>0.1M)
        {
            Console.WriteLine("Alert,10%stock price increase!");
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















