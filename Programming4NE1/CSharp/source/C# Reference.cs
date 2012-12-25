// Arrays 

type [ * ]  // [ * ] is the set: [ ] [ , ] [ , , ] [ etc. ]
+ array-name =
[
  new type [ dimension+ ] [ * ] * ; |
  { value1, value2, ... } ;
]

// Array Example
byte[ ] arr1 = new byte[ 10 ] ; 
int[ ] arr2 = { 0, 1, 2 } ; 


// Attributes

[ [ target: ] ? attribute_name ( 
positional-param+ |
[ named-param+, [ named-param =
				expr ] + ) ? ]

// Attributes Example 
[ assembly:CLSCompliant ( false ) ] 
[ WebMethod ( true, 
   Description = "My web method" ) ] 


// Break statement
break ; 

// Checked 
checked ( expr )

// Checked Example
short x = 32767
int i = checked ( ( short ) ++x ) ; // Throws exception

// Checked 
checked [ statement | statement_block ] 

// Checked Example
public short foo ( ) 
{
short x = 32767 ; 
   checked  // Throws exception
   {
   return ++x ; 
   }
}

// Unchecked
unchecked ( expr ) 

// Unchecked Example
short y = 32767 ; 
int j = unchecked ( ( short ) ++y ) ; 

// Unchecked
unchecked [ statement | statement_block ] 

// Unchecked Example
public short bar ( ) 
{
short y = 32767 ; 
   unchecked // Silently overflows
   {
   return ++y ; 
   }
}

// Class Declaration
attributes? unsafe? access_modifier?
new?
[ abstract | sealed ]?
class class_name
[ : base_class | 
: interface+ |
: base-class, interface+ ]?
{ class_members }

// Class Declaration Example
public class MyClass : Base. IFoo 
{
// ...
}


// Constant Declaration
const type [ variable = const_expr ]+ ; 

// Constant Declaration Example
const int xyzzy = 42 ; 


// Constant Fields
attributes? access_modifier?
new?
const type [ constant_name = 
					constant_expr ] + ; 

// Constant Fields Example
internal const byte fnord = 23 ; 

// Continue Statement 
continue ; 

// Delegates 
attributes? unsafe? access_modifier?
new?
delegate
[ void | type ]
delegate_name { parameter_list } ;

// Delegates Example
public delegate void
   MyHandler ( object s, EventArgs e ) ; 


// Destructors
attributes? unsafe? 
~class_name ( ) 
statement_block

// Destructors Example
~SomeClass( ) 
{
 // destructor code
}


// Do While Loops
do
  [ statement | statement_block ] 
while ( Boolean expr ) ; 

// Do While Example
int i = 0 ; 
do 
{
Console.WriteLine ( i++ ) ; 
} while ( i < 10 ) ; 


// Empty Statements
;

// Empty Statements Example
i = 0 ; 
while ( i++ < 10 )
 ;  // Take no Action
 Console.WriteLine ( i ) ; // Prints 11


 // Enums
 attributes? access_modifier?
 new?
 enum enum_name [ : integer_type ]? 
 {
[ attributes? enum_member_name
[ = value ]? ]* 
 }

 // Enums Example
 [ Flags ] public Enum Color : long
 {
    Red = 0xff00,
    Green = 0x00ff00,
    Blue = 0x0000ff
 } ; 
 // ...
 // prints "Green" "Red"
 Color yellow = ( Color ) 0xffff00 ; 
 Console.WriteLine ( yellow ) ; 

// Events
attributes? unsafe? access_modifier?
[
 [ [ sealed | abstract ]? override ] |
 new? [ virtual | static ]?
 ]?
 event delegate_type event_name

 // Events Example
 event MyDelegate OnClickedSomething ; 
 // ...
 OnClickedSomething ( arg1, arg2 ) ; 


 // Event Accesors
attributes? unsafe? access_modifier?
[
 [ [ sealed | abstract ]? override ] |
 new? [ virtual | static ]?
 ]?
 event delegate_type event_accesor_name
 {
  attributes? add statement_block
  attributes? remove statement_block
 }

 // Event Accesors Example
 event MyDelegate OnAction
 {
   add
   {
   // ...
   }
   remove
   {
   // ...
   }
 }


 // Expression Statements
[ variable = ]? expr ; 

 // Expression Statements Examples
 a = 10 * 10 ; 

 a++ ; 

 b = ++a ; 


 // Fields
attributes? unsafe? access_modifier?
new?
static?
[ readonly | volatile ]? 
type [ field_name [ == expr ]? ]+ ;

// Fields Example
protected int agent = 0x007 ; 


// Fixed Statements
fixed ( [ value_type | void ]* name =
					[ & ]? expr )
   statement_block

   // Fixed Statements Example
   byte[ ] b =  {  0, 1, 2 } ; 
   fixed ( byte* p = b )
   { 
*p = 100 ; // b[0] = 100 
   } 


   // For Loops
   for ( statement ) ; 
	Boolean_Expr ; 
	statement? ) 
	[ statement or statement_block ]? 

// For Loops Example
for ( int j = 0 ; j < 10 ; j++ )
Console.WriteLine ( j ) ; // prints 0 - 9


// For Each Loop
foreach ( type_value in IEnumerable )
statement OR statement_block

// For Each Loop Example
StringCollection sc = 
	new StringCollection ( ) ; 
sc.Add ( "Hello" ) ; 
sc.Add ( " World" ) ; 
foreach ( String s in sc )
Console.WriteLine ( s ) ; 


// Goto Statement
goto statement_label ; 
goto case_constant ; 

// Goto Example
i = 0 ; 
MyLabel:
if (++i < 100 )
goto MyLabel ; 
Console.WriteLine ( i ) ; 


// If-Else Statement
if ( Boolean_expr ) 
	[ statement OR statement_block ] 
[ else 
	statement OR statement_block ]?

// If-Else Example
if ( choice == "A" )
{
// ...
} 
elseif ( choice == "B" )
{
// ...
} 
else
{
// ...
} 


// Indexers
attributes? unsafe? access_modifier?
[
	[ [ sealed OR abstract ]? override ] OR
	new? [ virtual OR abstract OR static ]? 
	]?
	type this [ attributes? [ type_arg ]+ ]
	{
	attributes? get	// read only
		statement_block
	attributes? set	// write only
		statement_block
	attributes? get	// read-write
		statement_block
	attributes? set 
		statement_block
	} 

// Indexers Example
string this [ int index ]
{
	get
	{
	return somevalue ; 
	}
	set
	{
	// do something with implicit "value" arg
	} 
} 


// Instance Constructors
attributes? unsafe? access_modifier? 
class_name ( parameter_list ) 
[ :[ base OR this  ] ( argument_list ) ]? 
statement_block

// Instance Constructors Example
MyClass ( int i ) 
{
// perform initialization
} 
// initialize with default
MyClass ( ) : this ( 42 ) { } 


// Interfaces 
attributes? unsafe? access_modifier? 
new?
interface interface_name
[ : base_interface+ ]? 
{ interface_members }

// Interface Example
interface IFoo : 
	IDisposable, IComparable
{
// member declaration
} 


// Lock Statement
lock ( expr ) 
[ statement OR statement_block ] 

// Lock Statement Example 
lock ( this )
{
int tmp = a ; 
a = b ; 
b = tmp ; 
} 


// Method Declaration Syntax
attributes? unsafe? access_modifier?
[
	[ [ sealed OR abstract ]? override ] OR
	new? [ virtual OR abstract OR static extern ]? 
	]?
	[ void OR type ]
	method_name ( parameter_list ) 
	statement_block

// Method Declaration Example
public abstract int MethA ( object o ) ; 
public virtual void MethB ( int i,
						object o ) 
{ 
  // statements
} 


// Namespace
namespace name+
{
using_statement*
[ namespace_declaration OR
  type_declaration ]* 
} 

// Namespace Example
namespace CompanyName.ProjectName 
{
using System ; 
interface IFoo : IComparable { } 
public class MyClass { } 
} 


// Parameter List 
[ attributes? [ ref OR out ]? type arg ]*
[ params attributes? type [ ] arg ]? 

// Parameter List  Example
void MethA ( ref int a, out int b ) 
{
b = ++a ; 
} 
void MetB ( params string [ ] args ) 
{ 
foreach ( string s in args ) 
	Console.WriteLine ( s ) ; 
} 
// ...
int a = 20, b ; 
MethA ( ref a, out b ) ; 
Console.WriteLine ( "a = {0}, b = {1}", 
					a, b ) ; 
MethB ( "Hello ", "World" ) ; 

// Properties
attributes? unsafe? access_modifier?
[
	[ [ sealed OR abstract ]? override ] OR
	new? [ virtual OR abstract OR static  ]? 
	]? 
	type property_name 
	{ [ 
	attributes? get	// read only
		statement_block
	attributes? set	// write only
		statement_block
	attributes? get	// read-write
		statement_block
	attributes? set 
		statement_block
	] } 


// Properties Example 
private string name ; 
public string Name 
{ 
   get 
   { 
   return name ; 
   } 

   set 
   { 
   name = value ; 
   } 
}


// Return Statement
return expr? ; 

// Return Statement Examples
return ; 

return x ; 


// Static Constructors
attributes? unsafe? extern? 
static class_name ( ) 
statement_block

// Static Constructors Example
static MyClass ( ) 
{ 
// initialize static members
} 


// Struct Declaration
attributes? unsafe? access_modifier? 
new?
struct struct_name [ : interface+ ]?
{ struct_members }

// Struct Declaration Example 
public struct TwoFer
{ 
public int part1, part2 ; 
} 


// Switch Statement 
switch ( expr ) 
{ 
[ case constant_expr : statement* ]*
[ default : statement* ]?
} 

// Switch Example 
switch ( choice ) 
{ 
case "A": 
// do something
break ; 
case "B" : 
// do something, then branch to A
goto case "A" ; 
case "C" : 
case "D" : 
// do something
break ; 
default: 
Console.Write ( "Bad Choice" ) ; 
break ; 
} 


// Throw Statement
throw exception_expr? ; 

// Throw Example
throw new
	Exception ( "something's wrong" ) ; 


// Try Statements
try statement_block
[ catch ( exception type value? )? 
  statement_block ]+ OR
 finally statement_block OR
 [ catch ( exception type value? )? 
 statement_block 
 finally statement_block 

// Try Statements Example
try 
{ 
// do something
} 
catch ( Exception )
{ 
// recover
} 
finally
{ 
// This will always be called 
} 

// Using Statement 
using ( declaration_expr ) 
  [ statement OR statement_block ]

// Using Example
using ( StreamReader s= new StreamReader ( "ReadMe.txt" ) ) 
{ 
// ...
} 
// s is disposed here


// Variable Declaration
type [ variable [ = expr ]? ]+ ; 

// Variable Declaration Examples
long a, b, c ; 
int x = 100 ; 


// While Loops
while ( Boolean_expr ) 
  [ statement OR statement_block ]

// While Loop Example 
int i = 0 ; 
while ( i < 10 ) 
{ 
Console.WriteLine ( i++ ) ; 
} 
