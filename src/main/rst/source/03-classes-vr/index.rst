.. _classes-vr:

Classes Model Virtual Reality
#############################

Here is a slightly provocative statement: 
*A software scientist builds a virtual reality --- 
an electronic version of real-life" --- in a computer*.

For example, a spreadsheet program is a virtual sheet of grid paper that
includes a helper "minion" who adds up the rows and columns each time a human
enters a number into the grid.
A computerized game (card game, Dungeons and Dragons, etc.) is a virtual reality
of terrain and individuals, some of which are controlled by humans,
some of which are not.
A database program is a virtual filing cabinet whose file folders are linked
together with complex virtual strings and clips.

Now, if you want to build a virtual reality inside a computer, you must ask what
the entities will be.
You design their blueprints, and you activate them --- bring them to life,
as many as you want.

*Classes* are used in object-oriented languages to define the
"blueprints"/"genetic codes" and from them we construct *objects*.


Attributes, Abilities, and Responsibilities
*******************************************

A real-life dog is an entity that has attributes (gender, breed, height, weight,
maybe a name) and abilities (can bark, can bite, can eat, can run,
can fetch newspaper, can wag tail).
A "responsibility" is an activity that an entity must do; a dog might have the
responsibility to bark when there is an intruder.
Even real-life entities that we consider inanimate have attributes and
abilities: A car is inanimate, has lots of attributes, and has the ability to
propel a human to Chicago or New York.
(A car is unlikely to have responsibilities, however.)
When we computerize dogs and cars, their attributes, abilities, and
responsibilities will be coded in class definitions as 
*fields*, *methods*, and *commands*.

Now consider a card game: In a card game, a "card" is an entity with attribute
suit (spades, hearts, diamonds, clubs) and attribute count
(2, 3, 4, ..., king, ace).
A card has few abilities --- maybe it can "tell" you its suit and count, and
it has no responsibilities.
A "card deck" is an entity that holds cards inside it, can "shuffle itself" and
can yield ("deal") cards, one at a time. A deck has no responsibilities.

But a card game has other entities, who do have resposibilities:
the dealer (who owns the card deck, who deals from it, and who enforces the
rules of the game) and the players (each one owns a "hand" of cards and plays
the game).
We code these entities as class definitions.

Identifying Entities, Attributes, Abilities, and Responsibilities
=================================================================

Virtual reality is fascinating because what we consider as inanimate objects in
the real world are "alive" in the virtual world, e.g., a playing card.
And there are concepts that are not entities in the real world that exist as
entities in the virtual world, e.g., a "hand" of cards.
We must visualize the virtual world that we build within the computer before 
we type a line of code.
*We must make a design before we build.*

Consider the card game, Blackjack ("21"), where a dealer gives two cards to
each player, and a player collects more cards to obtain a score for her hand
that is as close as possible to 21 without exceeding it (else the player loses).
(In Blackjack, a numbered card has its number as its value, a face card has 10
as its value, and an Ace can be valued at *either* 1 or 11, as the player chooses.)
The player with the highest score <= 21 is the winner.

Watch this video of a round of Blackjack.
What are the entities and their abilities and responsibilities?
What are the classes?

`How to play blackjack, part 1 <http://www.youtube.com/watch?v=PXyHBOVNeEk>`__.


Class
*****

Here is an example of a playing card that might be coded in C#:

.. code-block:: c#

   // A _NAMESPACE_ IS THE SAME THING AS A VISUAL STUDIO PROJECT:
   namespace CardConcepts {

     // AN _ENUMERATION_ IS A NEW "PRIMITIVE DATA TYPE" THAT YOU DEFINE:
     // enumerations of the Suits and Counts that a playing card can have:
     public enum Suit { Spades, Hearts, Diamonds, Clubs };
     public enum Count { Ace, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King };

     // CLASS FOR CONSTRUCTING A PLAYING CARD:
     public class Card {
       public readonly Count count; // THIS IS A _FIELD_; SO IS THE LINE BELOW:
       public readonly Suit suit;   // "readonly" means var's value cannot change

       // THIS IS A _CONSTRUCTOR METHOD_; IT TAKES TWO _PARAMETERS_:
       public Card(Count a, Suit b) { count = a;  suit = b; }

       // THIS IS A _METHOD_; IT RETURNS AN ANSWER:
       // returns the int value of a card in Blackjack (it assumes an Ace has value 1)
       public int BJvalue() {
         int i = (int)count + 1;   // obtain int value that underlies the Count
         if (i > 10) { i = 10; }   // in Blackjack, face cards have value 10
         return i;
       }

       // returns the string value of a card; overrides default  ToString  coding
       public override string ToString() { return count + " of " + suit; }
     } 
   }
   
Make certain you understand all the constructions and all the comments in the
above example.
The fields in class Card list its attributes, count and suit;
the methods are the abilities.
Although inanimate, a card can tell you its Blackjack value and its name
(a string).

The class is saved in a Visual Studio project named CardConcepts.
In the main program, we construct objects,

.. code-block:: c#

   public static void Main() {
     Card c1 = new Card(Count.Ace, Suit.Hearts);
     Console.WriteLine("card {0} has value {1}", c1.ToString(), c1.BJvalue());
     if (c1.suit == Suit.Clubs) {
       Console.WriteLine("it's a club!");
     }
   }
   
and the card entities come to (virtual, electrical) life.


Unit Testing
************

A program is an assembly of objects constructed from classes.
A class by itself is not a program and might not "execute" all alone.
This is a serious problem in modern software engineering ---
if we develop a complex software system in stages, we want to design, build,
and test the components (classes) one at a time, so that when we assemble them,
we have high confidence that the assembly operates as desired.

How do we test and validate the quality of a class that cannot "execute" all alone?

There are special tools to test a class alone; 
Visual Studio provides an easy way to write a *test harness* for *unit testing*
an individual class.
(Like its name suggests, "unit testing" is the testing of one unit of a system.)

A unit test of a class is a script of actions that use one or more objects
constructed from the class.
The script exercises the attributes and methods.
There should be enough unit tests that all the attributes and methods are
exercised, in all possible, significant orders.

That last phrase is important --- most classes are defined with multiple methods,
where the methods are to be used in a certain order, a *protocol*.

For example, here is the protocol for using the methods of a text-file object:

1. open the file in mode ``M``, where ``M`` is either ``read`` or ``write``

2. do operation ``M`` multiple times

3. close the file

When we unit-test ``class TextFile``, we test that it operates properly with the
proper protocol, and we test that it does not corrupt its contents if a caller
violates the protocol:

.. code-block:: c#

   public enum FileMode { read, write, available };
 
   class TextFile {
     private string filename;
     private FileStream address_on_disk;
     private Mode mode;  // should be  Mode.Read  or  Mode.Write

     public TextFile(string name, Mode mode) { 
       // ...code to initialize  mode  and open the file
     }

     public string ReadLine() {
       // ... code to read textline from filename, provided mode == Mode.Read
     }

     public string WriteLine() {
       // ... code to write textline to filename, provided mode == Mode.Write
     }

     public bool CloseFile() { mode = Mode.available; }
  }
  
The unit tests for ``class TextFile`` should include scripts that follow the
proper protocol, as well as scripts that call methods in the wrong order
(e.g., construct, close, read) as well as scripts that call methods improperly
(e.g., construct a read-file and then write to it).

The unit tests should be collected together, used, and reused while the class is
coded, and maintained.
The unit tests form a "validation suite" for establishing confidence in the
quality of the class code.

Unit Testing in Visual Studio
=============================

The details are found course notes on :ref:`unit-testing`.
For our card example, say we coded ``class Card`` in Visual Studio in solution
``CardConcepts``.
If you look in VS's Solution Explorer window, you see that solution 
``CardConcepts`` holds one *Project*, also named ``CardConcepts``.
And within the project is a file, ``Card.cs``, that holds ``class Card``.

Here is an example of a test class with a test method, ready to run:

.. code-block:: c#

   PENDING
   
This code lives in ``CardUnitTest.cs`` within Project ``UnitTests`` within
Solution ``CardConcepts``.
   
To run the unit tests, you can use the "Run" (or "Debug") "All tests" menu item 
under the Visual Studio "TEST" menu.

Code Coverage
=============

It is considered best practice if your test suite exercises all 
(non-test) code in your solution.
Visual Studio has a code coverage analysis tool that can tell you if you are
missing exercising certain parts of your code. 
You can run the code coverage analysis by selecting ``Analyze Code Coverage`` 
and ``All Tests`` under the ``TEST`` menu. 

For more information, see MSDN's
`Using Code Coverage to Determine How Much Code is being Tested <http://msdn.microsoft.com/en-us/library/dd537628.aspx>`__
article.

----

.. raw:: html

   <p align=right><small><em>
   These lecture notes were adapted from David Schmidt's CIS 501, Spring 2014, 
   <a href="http://people.cis.ksu.edu/~schmidt/501s14/Lectures/Lecture02S.html">Lecture 2</a>
   course notes.
   </em></small></p>
