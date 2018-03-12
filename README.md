Week 11: Methods
================

This week we'll be going over the concept of _methods_ in object oriented programming.

To start off, we'll discuss [what][what a method _is_], in more general terms, to build some fundamental knowledge about computer programming, and gain insight into what advantages methods give us. Afterwards, we'll discuss how a method is defined in C#, specifically what a method [signature][signature] consists of, and what it means for our code. Finally, we'll go through how to specify [parameters][method parameters] and the different implications of these.

We'll set off some time for small tasks in between topics, so you can apply your newly aquired theory in practice.

# What _is_ a method? [what]

Contrary to popular belief, computers are fairly dumb machines, which do no more than exactly what we tell them to do. When you get down to it, a computer knows and acts only based on definite truth, expressed through binary code. What we call software, is essentially a series of instructions for the computer, in the form of machine language/binary, which acts on the computers hardware capabilities to do cool stuff, like showing cat pictures, calculating taxes, or playing bad pop music. All of this is achieved through a series of logic circuits, registers, and clever tricks. Entire books would be needed to cover the lowest level internals of how computers work (and a _much_ more knowledgable writer), but luckily that's not something we need to concern ourselves with as others have already done so for us.

## Instructions, jumps, and foundations

In programming, we deal a lot with "abstractions". One of the lowest levels of abstractions in programming, would be what is known as an "assembly language". An assembly language is a low-level programming language, typically tied to a certain architecture's machine code instructions. It provides a programmer with the ability to express instructions, using plain text, which can be compiled to native machine code. Instructions are read from top to bottom, with one instruction per line. One common instruction is `JMP` aka. jump (and derivatives), which moves the [instruction pointer][1.1] to a specific instruction in the instruction set. The instruction pointer is essentially the thing that keeps track of which line of code we're currently on. The ability to move the instruction pointer allows for flow control in our programs, such as selection statements (`if`) and iteration (`for`/`while`), by jumping to or perhaps skipping certain instructions. Essentially it allows us to (somtimes conditionally) run or rerun certain instructions.

Now imagine you're writing a cool piece of software, which has to do a certain subset of instructions multiple times, and not necessarily in a row. You could simply repeat the subset of instructions throughout your program, but what if you at a later time need to adjust this subset of instructions to accommodate logical changes, or fix some bug? You'd have to go to through every instruction subset affected, and apply the changes to each of them. In simple terms, that'd be quite a hassle, and we'd want to avoid having to do so when possible - programming is all about being lazy enough to get the computer to do things for you, after all. This is one case where "jumping" between instructions really come in handy: we cound simply jump to **the same** subset of instructions, whenever we need to, thereby containing it in one single location, instead of repeating it throughout our program. So whenever we need to run this subset of instructions, we jump to it, and then jump back. This is what we call a _procedure_, _subroutine_, _function_ (not to be confused with a mathematical function) or even _subprogram_, which are terms you might recognize from last week, where Rune briefly touched on structured programming.

_Note: you may see similarities between the `goto` statement and `JMP` instruction, and remember that `goto` **is evil**, which is definitely true, but only so because it's been abstracted away for you by the high-level functionality of C#._

## Methods in C#

>Well that's cool and all, but what does this have to do with methods in C#? 
>
>- You, probably

Now that we have at least some kind of basic understanding as to how _functions_ work on a low-level, let's move a couple of abstractions up, to something more understandable: C#.

In C#, we have the concept of "methods", defined as followed by MSDN:

>A method is a code block that contains a series of statements. A program causes the statements to be executed by calling the method and specifying any required method arguments. In C#, every executed instruction is performed in the context of a method.
>
>- [MSDN][1.2]

Let's translate that to terms we've previously used:

>A method is a code block that contains a series of statements.

Let's start off by saying that a _statement_ is synonymous with what we've previously called an _instruction_, but simply on a higher level, such as a variable assignment, `if` statement, `for` loop, etc. A code block is simply what we previously called a "subset of instructions", that is, it's a bunch of statements inside a matching pair of brackets.

```
// Note that this is just an arbitrary example
static void ExampleMethod()
{ // Opening bracket indicates the start of our code block
    int n = 10; // This is a statement
    int m = 0; // This is a statement
    
    if (true) // This is a statement
    { // Start code block
        n = 5; // This is a code block with a statement in it
    } // End code block
    
    for (int i = 0; i < n; i++) // This is a statement
    { // Start code block
        m = m + i; // This is also a code block
    } // End code block
} // Closing bracket indicates the end of our code block
```

As you can see, code block can even contain other code blocks.

>A program causes the statements to be executed by calling the method and specifying any required method arguments.

This is just like "jumping" to our subset of instructions, as explained previously, when we need to, during the flow of our program. Remember that what we're doing here, is grouping a set of statements into a code block (see above), and simply running these.

```
// This calls our arbitrary example method from above,
// which results in the statements withing being run.
ExampleMethod();
// We can do it again...
ExampleMethod();
// ..and again, just because we can
ExampleMethod();
```

A method is really just a code block, with an assigned name. It's super easy to call our method, so our arbitrary code can run where and whenever we feel like it.

One **very important rule** in C# is that everything is **case sensitive**. So calling `examplemethod()` above would result in an error, as the method is defined as `ExampleMethod()`.

As for "specifying any required method arguments", we'll return to this [later][parameters].

_Side note: "calling" a method is synonymous with "invoking" a method, just for future reference._

>In C#, every executed instruction is performed in the context of a method.

This is where the term "method" will start to have a semantically different meaning than our previously established "procedure", "subroutine", and "function".

Context is key, always. But context of what? This is where object-oriented thinking and programming starts making more sense, but also becomes quite a bit more complicated.

Up untill now, I've used the idea of "jumping" fairly liberally. I've stated that we can jump to a subroutine "whenever we need to", which in assembly is true, but not so for higher level languages like C#. In C#, and other high-level languages, we have the idea of _context_ to keep in mind. _Context_ is the place in which a piece of code is located, or the state the program is currently in. The simplest of contexts, is the "global" context. The "global" context is that of the entire program. In C#, our global context starts and ends with our `Main()` method. Of relevance here is the `static` keyword, which you undoubtably used on some methods prior to this. As you might know, marking a method as `static` binds it to the class on which it is defined, but it may be called anywhere you want, so long as you reference the class.

```
class Program
{
    void static Main()
    {
        // We call method Greet() directly on class Foo
	Greeter.Greet();
    }
}

class Greeter
{
    public static void Greet()
    {
        // WriteLine() is in fact also just a static method
	// located on .NET's build in System.Console class!
        Console.WriteLine("Hello!"); // Hello!
    }
}
```

Really, a `static` "method" is synonymous with a "function".

_Note: all methods from here on are marked `public` for simplicity, we'll discuss what this means later._

You might even notice that `Program.Main()` is also a static method, which is simply a convention specified in the C# language specification, to standardise application startup.

So `static` methods are available in the `global` context. What about non `static` methods then? As you may recall, in object oriented programming, we have these "classes", which may be instantiated into "objects".

```
class Program
{
    void static Main()
    {
	// Create an instance of Greeter
	Greeter greeter = new Greeter();

	// Call Greet() on the new instance of Greeter
	greeter.Greet(); // Hello!
    }
}

class Greeter
{
    public void Greet()
    {
	// We can still call static methods here, 
	// even though Greet() isn't static
        Console.WriteLine("Hello!");
    }
}
```

The above example illustrates a very simple point: _non_-`static` methods must be called on **instances** of a class, that is on _objects_.

The `Greet()` method can _only_ be called on actual instances of our `Greeter` class, meaning `Greeter.Greet()` wouldn't work! So contrary to the previously mentioned _global_ context, we can call this an _instance_ context, or an _object_ context: the context is no longer the program in it's entirety, but a specific instance of our `Greeter` class.

To further illustrate this, let's add some state to our greeter, making every instance unique.

```
class Program
{
    void static Main()
    {
	// Create some instances of our Greeter, with unique greetings
	Greeter traditional = new Greeter("Hello!");
	Greeter casual = new Greeter("Hey!");
	Greeter cool = new Greeter("Yo!");

	traditional.Greet(); // Hello!
	casual.Greet(); // Hey!
	cool.Greet(); // Yo!
    }
}

class Greeter
{
    private string _greeting;

    public Greeter(string greeting)
    {
	// We want a unique greeting for each instance of our greeter
        _greeting = greeting;
    }

    public void Greet()
    {
	// Now the greeter will use the instance specific greeting
        Console.WriteLine(_greeting);
    }
}
```

Methods are, like attributes, defined as _members_ of a class.

This is the very foundation of all object oriented programming. While it might seem redundant for now, with our small arbitrary examples, you'll come to learn that objects are **very** powerful tools indeed. 

_Note: "context" may be synonymous with "scope" in some cases, but don't worry too much about it._

# Signature [signature]

A method consists of two things:

1. A signature
2. An implementation

In C#, all behavioural code will be inside of methods - that means all of your program logic. But theres more to methods than the code it runs upon invocation. We have to consider the name of the method, it's accessibility, return type, and parameters. 

The code of a method, as described in [the previous part][what], is grouped into a code block. This is known as the "method body", and is the "implementation" of the the method. The method definition itself, meanwhile, is known as the methods "signature" or the "method head", if you wish. The [official C# language specification for method signatures][2.1] is a bit of a mouthful, so I'll simplify it as follows:

```
[modifiers] <return_type> <name>([parameters])
```

I'll run through each part in detail here, but [parameters][parameters] will have it's own for part afterwards.

`modifiers` include access (`public`, `private`, etc.), `static`, and others which we'll omit for brevity. These are all optional, but if access is omitted, the method will be `private` by default.

Of these, you should know how `static` works, and if not you can reread the [orevious part][what]. Of special interest, however, is the access modifier, which defines the _visibility_ of the method, or in more practical terms, _who may call_ the method.

As mentioned, methods definitions will default to being `private`. As is the case with other class members, a `private` method may only be invoced by the defining class itself. This means that for a class `Foo` with a `private void Bar()`, only other methods of ´Foo` may call `Bar`.

```
class Program
{
    void static Main()
    {
        Foo f = new Foo();

	f.Baz(); // "We reached Bar!"
	f.Bar(); // Illegal operation, since Bar() is private!
    }
}

class Foo
{
    public void Baz()
    {
        Bar();
    }

    private void Bar()
    {
        Console.WriteLine("We reached Bar!");
    }
}
```

A method being `public` means just the opposite: any consumer of our class may call it, as seen with `Baz()` above.

The methods marked as `public`, will define the public _interface_ of your class. Typically, you want to mark **only the methods necessary for your consumer** to use as `public`, and keep everything else `private`. This is part of what is known as "encapsulation", which is meant to ensure loose "coupling", in which we attempt to keep as much information about the inner workings of our objects private, to minimize necessary changes across our program in the future. `private` methods are used for grouping the inner logic of your classes, whereas `public` methods expose the functionality which the class should provice to it's consumers.

Enacpsulation and coupling will be a major focus next semester, so don't worry too much about it for now, but keep it in the back of your mind.

`return_type` defines the _resulting type_ of calling the method. A `return_type` is any data type defined in C#, including (but not limited to) `int`, `string` or any of your defined classes. 

```
class Program
{
    void static Main()
    {
        Fox fox = new Fox();
	// Notice that the datatype of sound must match that of
	// the return type of fox.GetSound()
        string sound = fox.GetSound();

        // I'll leave the explanation of the output as an exercise
	// you can play around with in your own time
	Console.WriteLine("What does the fox say? " + sound);
    }
}

class Fox
{
    private string _sound;

    public string GetSound()
    {
        return _sound;
    }
}
```

Make note of the `return` statement, which specifies the value returned by the method. The values datatype must match that of the methods `return_type`. Of special note is that when a `return` statement is encountered, C# **will exit** the method call.

```
class Fox
{
    private string _sound;

    public string GetSound()
    {
        return _sound;
	// The following will never be output
        Console.WriteLine("This method is a really bad joke, I know.");
    }
}
```

The exception to this rule is, that a method may be marked as `void`, which means that the method produces no result.

```
class Program
{
    void static Main()
    {
        Fox fox = new Fox();
        
	fox.Jump(); // Produces output
	int a = fox.Jump(); // Causes compiler error, since fox.Jump() is void
    }
}

class Fox
{
    private string _sound;

    public string GetSound()
    {
        return _sound;
    }

    public void Jump()
    {
        Console.WriteLine("The quick brown fox jumps over the lazy dog");
    }
}
```

Of special note for `void` methods is, that they may still use the `return` statement, albeit without any actual value. This will simply exit the method.

```
class Fox
{
    private string _sound;

    public string GetSound()
    {
        return _sound;
    }

    public void Jump()
    {
        return;
	// Will never output anything!
        Console.WriteLine("The quick brown fox jumps over the lazy dog");
    }
}
```

Methods can typically be categorized as either being a _command_ or a _query_. A _command_ is method which performs some action, which may have side effects such as changes in state. These are typically `void`, though having a return value, such as whether or not the command was a success, is very common. A _query_ is a method which as no side effects, and always results in some value - as such these are **never** void. In our `Fox` class above, `Jump()` is an example of a command (with no side effects, but a command still), while `GetSound()` is a query.

`name` simply defines the name of our method. The `name` can be whatever we choose, with a few limitations:

* Only a constructor method may be named the same as the containing class
* A method name MUST only contain alphanumeric characters, numbers, and underscores
* A method name MUST not begin with a number

For naming, Microsoft has a set of [recommended conventions][2.2], which I suggest you follow, as they're very standardised throughout the C# ecosystem.

# Parameters [parameters]

## Pass by value or reference

## Optional parameters

## `out` parameters

## `ref` parameters


[1.1]: https://en.wikipedia.org/wiki/Program_counter "Instruction pointer"
[1.2]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/methods "MSDN on methods"
[2.1]: https://github.com/dotnet/csharplang/blob/master/spec/classes.md#methods "Method specification"
[2.2]: https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/general-naming-conventions "General naming conventions"
