.. _multi-threaded:

Multi-threaded Execution
########################

A program's activation stack ("call stack") remembers the progress of execution.
The program, its instruction counter, and the activation stack are a thread of
execution.
The norm is that there is one thread of execution (and so, one activation stack).

When you use Visual Studio to create a Form with active buttons, the ``Main``
method looks like this:

.. code-block:: c#

   static void Main() {
     Application.EnableVisualStyles();
     Application.SetCompatibleTextRenderingDefault(false);
     Application.Run(new Form1());
     MessageBox.Show("Form1 has been terminated");
   }

The ``Application.Run(new Form1())`` command activates the Form object so that
the thread of execution (and the call stack) execute ``Form1``'s events
(button presses).
If ``Form1`` terminates, only then does control return to ``Main`` and the
message box appears.


Threads
*******

We can modify a program so that there are multiple threads of execution ---
multiple call stacks.
When we execute such a program, called a multi-threaded program, the computer's
processor divides its time between the threads.

The note on :ref:`multiple-gui-threads` show how to do this.
Here is an example, where two distinct forms, each with its own buttons and work
to do, are activated in one application:

.. code-block:: c#

   using System;
   using System.Collections.Generic;
   using System.Linq;
   using System.Windows.Forms;
   using System.Threading;  //  ADD ME

   namespace TestThreading {
     static class Program {
       [STAThread]
       static void Main() {
         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault(false);

         new Thread(Driver1).Start();   // ADD ME
         new Thread(Driver2).Start();   // ADD ME
         MessageBox.Show("Forms started in their own threads");
       }

       // ADD THESE PROCEDURES:
       static void Driver1() { Application.Run(new Form1()); }
       static void Driver2() { Application.Run(new Form2()); }
     }
   }

In C#, one constructs and starts a thread object, which holds commands that
execute with their own call stack --- each thread gets its own call stack.
Note that if ``Form1`` terminates and ``Main`` finishes, then ``RunForm2`` keeps
executing because it has its own call stack.


Race Conditions
***************

It is dangerous when two threads share an object in the Heap, because the
computer's processor can choose to pause a thread at any moment and execute
another thread.
Such a "processor time out" might occur at the worst possible moment.
Here is an example, where two threads are both seizing tokens held in a
shared object:

.. code-block:: c#

   namespace Race {

     // constructs an object that holds 100 "tokens" to give away:
     class Token {
       private int tokens = 100;

       // returns one token if available
       public bool getToken() {
         bool outcome = false;
         if (tokens > 0) { 
           tokens = tokens - 1;
           outcome = true;
         }
         return outcome;
       }
     }

     // a race between two threads to seize the most tokens
     class Program {
       static Token x = new Token();  // x  holds 100 tokens to give away

       // starts two threads, each of which grabs tokens:
       static void Main(string[] args) {
         new Thread(Run1).Start();  // start thread 1
         new Thread(Run2).Start();  // start thread 2
         Console.WriteLine("both threads initialized");
         Console.ReadLine();
       }

       static void Run1() { loop(1); }
       static void Run2() { loop(2); }

       // procedure that repeatedly seizes tokens and then prints result.
       // param: id - the index number of the thread that called the proc.
       static void loop(int id) {
         int success = 0;
         Random rand = new Random();
         while (x.getToken()) { 
           success = success + 1;
           Thread.Sleep(rand.Next(0, 8));   // pause for 0..7 milliseconds
         }
         Console.WriteLine("thread {0} has {1} tokens", id, success);
       }
     }
   }

If you repeatedly execute this application, you will find that the two threads
occasionally seize more than 100 tokens.
Why? Well, the processor is pausing and restarting threads at what appear to be
arbitrary times, and a thread might well be paused at point ``(*)`` or ``(**)``
in ``getToken``:

.. code-block:: c#

   if (tokens > 0 ) { // (*) 
     tokens = /* (**) */ tokens - 1;
     outcome = true;
   }

A pause at ``(*)`` means that the paused thread is ready to seize a token, but
now another thread can call ``getToken`` and seize for itself the token intended
for the paused thread.
A pause at ``(**)``, in the middle of the assignment, means that the paused
thread will reawaken and set variable tokens to an old, out-of-date value
(since other threads will have called getToken while the paused thread was
asleep).
(Recall the semantics of an assignment: ``L = E``:

1. ``L`` is evaluated to a location number;

2. ``E`` is evaluated to a storable value;

3. the value is deposited in the cell at the location.

Point ``(**)`` above marks the break between Steps 2 and 3.)

This situation is called a *race condition* and is virtually guaranteed to
happen in practice.
No data structure can be shared like this, without protection.


Locks
*****

A modern computer language provides a construct to ensure *mutual exclusion* of
threads that share an object.
That is, the mutual-exclusion construct will allow at most once thread to
execute code on the object, and other threads are not allowed to execute the
code until the one thread that has started eventually finishes
(even if the thread is paused for a while).

The best mutual-exclusion construct I know is called a *monitor*.
(Others are called *semaphores*, *critical regions*, and *conditional critical
regions*.)
C# implements a ``lock`` construction, which ensures mutual exclusion to an
object if you use it correctly. 
Here is how we insert a lock into the previous example:

.. code-block:: c#

   public bool getToken() {
     lock(this) { // enforce mutual exclusion on *this* object
                  //   for this method body
       bool outcome = false;
       if (tokens > 0) {
         tokens = tokens - 1;
         outcome = true;
       }
       return outcome;
     }  // end lock
   }

You place ``lock(this){...}`` around the code for every public method in the
class to ensure that at most one thread at a time will execute any of the public
methods in the object.
(The ``this`` is the handle to the object being locked and acts as the "key" to
lock and unlock.)

See the note on :ref:`using-lock` for other examples.
Mutual exclusion and multi-threading are important, and some of your later
courses will revisit the topics.

----

.. raw:: html

   <p align=right><small><em>
   This note was adapted from David Schmidt's CIS 501, Spring 2014, 
   <a href="http://people.cis.ksu.edu/~schmidt/501s14/Lectures/Lecture09S.html">Lecture 9</a>
   course note. © Copyright 2014, David Schmidt.
   </em></small></p>
