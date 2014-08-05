Using C# with Visual Studio and Git/GitHub
##########################################


Visual Studio and C#
********************

Visual Studio ("VS") helps you construct a C# project that you can test and 
later compile into an **.exe** or **.dll** file.
In this course, we will use Visual Studio 2013 Ultimate edition.

Accessing Visual Studio
=======================

As a K-State CIS student, you can download and install Visual Studio 2013 Ultimate
for free through to Microsoft Dreamspark store; please contact the CIS system
administration (e.g., via help@cis.ksu.edu) if you do not have a Microsoft
Dreamspark store account. 

Alternatively, you can access Visual Studio 2013 Ultimate via remote desktop to
``remote.win.cis.ksu.edu``. You need to use a remote desktop software specific
to your OS (e.g., 
`win <http://apps.microsoft.com/windows/en-us/app/remote-desktop/051f560e-5e9b-4dad-8b2e-fa5e0b05a480>`__, 
`linux <http://rdesktop.sourceforge.net>`__, 
`mac <https://itunes.apple.com/us/app/microsoft-remote-desktop/id715768417>`__).

Note that if you are accessing ``remote.win.cis.ksu.edu`` from off-campus, 
you will need to use K-State VPN software
(http://www.k-state.edu/its/security/vpn/) before connecting to it. 

Online C#/Visual Studio References
==================================

Use the web site www.dotnetperls.com as your "reference text" when you use 
Visual Studio to develop C# programs.
It is an easy-to-consume, example-driven introduction to the useful parts of
C#. Any details I omit here you will find in www.dotnetperls.com.

Microsoft Developer Network (http://msdn.microsoft.com) also has a lot of 
information regarding C# and Visual Studio (you can use the search box to look
for information on a specific topic).
Note that there are two GUI frameworks for C#/.Net: 
`Windows Form <http://msdn.microsoft.com/en-us/library/dd30h2yb(v=vs.110).aspx>`__ and 
`Windows Presentation Foundation (WPF) <http://msdn.microsoft.com/en-us/library/vstudio/ms754130.aspx>`__. 
For simplicity, we will use Windows Forms in this course.


Git/GitHub
**********

We will be using the `Git <http://www.git-scm.com>`__ distributed version 
control system and `GitHub <https://github.com>`__ to access some of the course 
materials. Thus, you need to have a GitHub account 
(see https://help.github.com/articles/signing-up-for-a-new-github-account).
You need to tell the instructor your GitHub username; the instructor will then
create a dedicated private repository for you to submit course exercises and 
assignments.

We will be using `Visual Studio Git integration <http://msdn.microsoft.com/en-us/library/hh850437.aspx>`__
with a very simple and specific Git workflow to sync your private repository with 
the instructor's GitHub repository; in-class exercise and assignment submissions
will be done by simply committing/pushing your changes to your private repository.


Creating A New Project
**********************

Open VS and click on "New Project".
A new window appears.
The three useful choices are:

* "Windows Forms App" (generates a default GUI)

* "Class Library" (for a standalone library class (.dll file))

* "Console App" (for a DOS-window-based app)

Remember to fill in the name of your new project on the bottom. 
Rod Howell's style is "RodHowell.CIS300.MyProjectName".
Technical note: actually, VS creates a "solution" that holds a "project"
(a project is a C# package).
It is possible to add a second project to the same solution:
You do this by right-clicking on the solution name in the Solution Explorer
window then then select ADD then NEW PROJECT.
If you look at the folder structure that is created, you will find a folder
holding the "solution" which holds two folders that are "projects" (C# packages).
Be careful if you do this trick.

Basic IDE Operations
====================

Click on green arrow to run app.
Use the "View" menu to make visible key subwindows such as
Toolbox, Solution Explorer, and Properties.


Console application
*******************

If you construct a new project that is a console application,
you will receive a class that contains a ``Main`` method. 
From this point, you can code vanilla C#, say, like the examples in 
Dave Schmidt's `CIS200 notes from 2008 <http://people.cis.ksu.edu/~schmidt/200s08/>`__. 
(Scroll to the bottom of the page for the relevant links.)


Windows Forms application
*************************

If you construct a new project that is a forms application,
you will receive a class, ``Form1.cs`` that holds a C# form widget.
You drag and drop widgets into it.
Note that the default file names are "Form1.cs" and "Program1.cs".
You can change these.
To do it, within Solution Explorer, right click on file name and use menu to
change it, e.g., "Form1.cs" to "View.cs" or "uxForm.cs".

If you are building a Forms App, click on the "Design" tab of "Form1.cs" to see
the GUI layout.
You can see the code by right-clicking on "Form1.cs" in the Solution Explorer
window and selecting "View Code", or you can double click on the GUI itself to
see its code.

Widgets
=======

You can change size of a widget by dragging its borders.
You can change its title by changing its "Text" value in the Properties window.
There are a lot of properties for a widget (e.g., Size, Anchor);
see the list of widgets and key properties below.

You add widgets to a GUI with the Toolbox.
For example, go to Toolbox, select Toolstrip and then click on the GUI to drop 
the widget.

You can change the Properties of the toolstrip.
(Click on the widget to activate its properties in the Properties window.) 
Each widget has a name, a font, a color, an anchor.
(You can Anchor a button so that it does not float in the layout in its parent
widget is resized.)

IMPORTANT: to change the var name of the widget in the source code, change the
"(Name)" entry in its Properties list. Eg., Change "toolstrip1" to "uxToolStrip".

Here are some widgets and key properties:

* Label: displays lines of text. 
  (Actually, it displays one string, but if there are "\n" characters in the
  string, it displays as multiple lines.)
  
* Button: A button can be "Enabled" (or "Disabled" --- see its Properties).

* Textbox (a place to type or display text): You can enable user typing into the
  box or not via "ReadOnly".
  
* Listbox (a place to show a list of textlines, which can be selected.
  See Selection mode to see how a user can select the lines.
  
* Toolstrip: a bar that holds widgets like buttons and menus.
  You click on a toolstip to add widgets to it, eg, a button.
  Use Properties to change the button's "(Name)" and its "Display style"
  (say, from "image" to text").
  
Each widget has a name, a font, a color, an anchor.
You can Anchor a button so that it does not float in the layout in its parent
widget is resized.
In Toolbox, in Common Components, you can find tools like Web Browser, that you
can select and insert. See www.dotnetperls for examples of other useful widgets.

It is also possible to add to Common Components a widget that someone else
(or you) has written.
Assume this widget is packaged as a .dll file.
We won't do much of that here, but check back to your CIS300 notes to see how
Dr. Howell did this.

Widget Event Handling
=====================

To add "the usual" event handler to a widget,
double click on the widget in the GUI display.
This generates an event-handler template in your class Form,
and you insert type the handler code. For example, for a button named, ``uxHome``,

.. code-block:: c#

   private void uxHome_Click(object sender, EventArgs e) {
     uxBrowser.GoHome();   // the code I added
   }

This handles the button click by calling method ``GoHome`` in object ``uxBrowser``.

IMPORTANT: there is a huge list of events associated with a widget.
To see them, click on the widget and in the Properties window, click on the
lightning bolt ("events") to see all the events to which event handlers can be
associated.
You click on an event, and VS will generate the appropriate template for its handler.

You should read Rod Howell's first few GUI-based assignments in CIS300 to get
tips for using VS to build widgets.


Using VS Debugger
*****************

To run an app, just press the green ▶ button on VS.
But you can stop the program in the middle of execution and look at the values
of its variables by using the debugger.
Here's how:

Set breakpoints: easiest way is to click to the left of the line where you want 
to step: click on the left vertical grey bar; a red blob will appear.
Or, use cursor to select a line where you want to stop.
Use DEBUG menu item and select TOGGLE BREAKPOINT.
This marks the line (you will see a blob at the left of the line).

Now, use DEBUG, START DEBUGGING.
The program will run and stop at the selected breakpoint.
In the window at the bottom, you should see the values of the variables that are
visible at the program point, and you will see the stack of unfinished method calls.
(If you don't see this stuff, select DEBUG, WINDOWS, LOCAL and also CALLSTACK 
and also AUTOS.)
Click the green button to continue to the next breakpoint.
(You can insert multiple breakpoints, of course.
You can remove a breakpoint by clicking on its blob or by selecting it with the
cursor and then use DEBUG, TOGGLE BREAKPOINT.)

You can also single-step (run-and-stop, one line at a time) using the "STEP INTO"
menu item in DEBUG.
Note the short-cut key for doing multiple steps.
Step-into will enter called methods, too.

You can single-step but not enter called methods by selecting "STEP OVER".

You can exit the currently active method and execute to the method's call point
by clicking "STEP OUT".

About the debug windows: in addition to LOCALS and CALL STACK and AUTOS, you use
WATCH to enter vars or exprs whose values you wish to query at each breakpoint.
You can use the IMMEDIATE window as an expression interpreter that uses the
current context at the current breakpoint.