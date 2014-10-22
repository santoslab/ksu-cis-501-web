.. raw:: html

   <br/>
   <font color="darkgray">
   <big><big><b>
   
Course Notes --- CIS 501: Software Architecture and Design, Fall 2014

.. raw:: html

   </b></big></big>
   </font>


.. _design-patterns-postlude:

Design Patterns Postlude: When to Use Them
##########################################

Almost all presentations of design patterns start by showing you patterns,
one after the other, until you have overdosed and cannot remember what any of
them are good for.

Here is a "reverse list-table", that lists the problems you might face when you 
are designing a system and which patterns might help your situation.
There are a few patterns that were not introduced in the previous lecture notes,
but you can look them up and learn them easily.

*But first*,

1. Use *interfaces* to define "plug-in" (exit) and "plug-out" (entry) points
   from/to each subassembly in your system.

2. When a connection point is just a single method, because there is no need to
   know if there is even a class/object on the other end, use a *delegate*.
   
----

  You have designed a complicated implementation of a data structure/data base, 
  and you do not trust your users to use the structure correctly.

* If it is complicated to traverse the structure, say to answer a query to it,
  incorporate *iterator* objects that collect the results from a traversal and
  hand them out to the user, one by one.
  
* If your data structure is organized in layers or levels, or
  it contains a mix of various classes of elements that it stores,
  use the *composite* layout to define it.
  
* Define a *facade* class that holds the methods for building a starter version
  of your data structure and methods for querying it and updated it.
  
* To handle complex, SQL-like, queries, implement an *interpreter*.
  
* If the structure holds hundreds or thousands of data objects all constructed
  from the same class, use the *flyweight* pattern to extract the data common
  to all the objects and save it in a "static" object that is shared by all
  the thousands of data objects.

----

  Your system holds a model assembly that is queried a lot, and you are worried
  that the entry to the model is a "bottleneck".
  
* In response to a client's login or access request, use a *factory method* to
  generate a helper object to give back to the client.
  
* The object that is returned to the client might act as a *remote proxy* or
  a *virtual proxy* to relieve the load on the model.

----

  Your subassembly builds compound objects that are assembled from 
  a mix-and-match kit of "features".
  (Think of how a car is assembled with features and how a laptop is assembled
  with features.)
  
* For software features that are field-based, use the *decorator* and 
  *composite* patterns.
  
* For software features that are method-based, use the *chain of 
  responsibility* or *command* pattern, which allow you to connect together
  objects that hold useful command code and to pass around command sequences
  as objects.

----

  You have written a driver or controller that is meant to work with different
  families of model objects that "plug into" the driver (e.g., a typesetter into
  which a font family is plugged or a graphics driver into which a widget family
  is plugged).

* Use the *abstract factory* pattern. It is one of the most important and
  well known patterns.

----

  Two assemblies need to be connected, and they use different protocols
  (data args, method names, order of method calls).
  
* Use an *adaptor*.

----
  
  You have connected multiple assemblies, and the result is a mess. 

* Use *observers* to decouple the assemblies.
  
* Construct a *mediator* (a controller-for-the-controllers) to enforce
  a complex protocol between controllers.
  
----

.. raw:: html

   <p align=right><small><em>
   This note was adapted from David Schmidt's CIS 501, Spring 2014, 
   <a href="http://people.cis.ksu.edu/~schmidt/501s14/Lectures/MiscS.html">Lecture 15</a>
   course note. © Copyright 2014, David Schmidt.
   </em></small></p>
