//: C02:HelloStrings.cpp
// The basics of the Standard C++ string class
#include <string>
#include <iostream>
using namespace std;

int main() 
{
string s1, s2; // Empty strings
string s3 = "Hello, World."; // Initialized
string s4("I am"); // Also initialized
s2 = "Today"; // Assigning to a string
s1 = s3 + " " + s4; // Combining strings
s1 += " 8 "; // Appending to a string
cout << s1 + s2 + "!" << endl;
} ///:~