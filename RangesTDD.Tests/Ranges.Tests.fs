module RangesTDD.Tests

open NUnit.Framework
open RangesProgram

// *************** CONSTRUCTOR ****************
[<Test>]
let ``Created range returns something``() =
    Assert.IsNotNull(Range("{2,3}"))

// *************** CONTAINS ****************
[<Test>]
let ``Range("(1,5)").Contains({2,3}) returns TRUE``() =
    Assert.IsTrue(Range("(1,5)").Contains([|2;3|]))

[<Test>]
let ``Range("(2,6]").Contains({3,6}) returns TRUE``() =
    Assert.IsTrue(Range("(2,6]").Contains([|3;6|]))

[<Test>]
let ``Range("[3,7)").Contains({3,7}) returns FALSE``() =
    Assert.IsFalse(Range("[3,7)").Contains([|3;7|]))

[<Test>]
let ``Range("[4,8]").Contains({3}) returns FALSE``() =
    Assert.IsFalse(Range("[4,8]").Contains([|3|]))

// *************** GetAllPoints ****************

[<Test>]
let ``Range("(1,3)").GetAllPoints returns 2``() =
    Assert.AreEqual([|2|], Range("(1,3)").GetAllPoints())

[<Test>]
let ``Range("[2,3]").GetAllPoints returns {2,3}``() =
    Assert.AreEqual([|2;3|], Range("[2,3]").GetAllPoints())

[<Test>]
let ``Range("(7,10]").GetAllPoints returns {8,9,10}``() =
    Assert.AreEqual([|8;9;10|], Range("(7,10]").GetAllPoints())

[<Test>]
let ``Range("[13,14]").GetAllPoints returns {13,14}``() =
    Assert.AreEqual([|13;14|], Range("[13,14]").GetAllPoints())

// *************** GetEndPoints ****************
[<Test>]
let ``Range("[3,8)").GetEndPoints returns {3,7}``() =
    Assert.AreEqual([|3;7|], Range("[3,8)").GetEndPoints())

[<Test>]
let ``Range("(10,18]").GetEndPoints returns {11,18}``() =
    Assert.AreEqual([|11;18|], Range("(10,18]").GetEndPoints())

[<Test>]
let ``Range("(5,50)").GetEndPoints returns {6,49}``() =
    Assert.AreEqual([|6;49|], Range("(5,50)").GetEndPoints())

[<Test>]
let ``Range("[22,25]").GetEndPoints returns {22,25}``() =
    Assert.AreEqual([|22;25|], Range("[22,25]").GetEndPoints())

// *************** ContainsRange ****************
[<Test>]
let ``Range("[15,17]").ContainsRange(Range("[15,18)")) returns TRUE``() =
    Assert.IsTrue(Range("[15,17]").ContainsRange(Range("[15,18)")))

[<Test>]
let ``Range("[10,11)").ContainsRange(Range("(9,11)")) returns TRUE``() =
    Assert.IsTrue(Range("[10,11)").ContainsRange(Range("(9,11)")))

[<Test>]
let ``Range("(29,35)").ContainsRange(Range("[29,35]")) returns FALSE``() =
    Assert.IsFalse(Range("(29,35)").ContainsRange(Range("[29,35]")))

[<Test>]
let ``Range("(32,43]").ContainsRange(Range("(3,5]")) returns FALSE``() =
    Assert.IsFalse(Range("(32,43]").ContainsRange(Range("(3,5]")))

// *************** OverlapsRange ****************
[<Test>]
let ``Range("(1,5)").OverlapsRange(Range("(3,18)")) returns TRUE``() =
    Assert.IsTrue(Range("(1,5)").OverlapsRange(Range("(3,18)")))

[<Test>]
let ``Range("[4,9]").OverlapsRange(Range("[5,10]")) returns TRUE``() =
    Assert.IsTrue(Range("[4,9]").OverlapsRange(Range("[5,10]")))

[<Test>]
let ``Range("(7,19]").OverlapsRange(Range("(1,7]")) returns FALSE``() =
    Assert.IsFalse(Range("(7,19]").OverlapsRange(Range("(1,7]")))

[<Test>]
let ``Range("[13,19)").OverlapsRange(Range("[19,25)")) returns FALSE``() =
    Assert.IsFalse(Range("[13,19)").OverlapsRange(Range("[19,25)")))

// *************** Equals ****************
[<Test>]
let ``Range("(3,5)").Equals(Range("(3,5)")) returns TRUE``() =
    Assert.IsTrue(Range("(3,5)").Equals(Range("(3,5)")))

[<Test>]
let ``Range("(25,28)").Equals(Range("(35,38)")) returns FALSE``() =
    Assert.IsFalse(Range("(25,28)").Equals(Range("(35,38)")))

[<Test>]
let ``Range("[7,11]").Equals(Range("(6,11]")) returns TRUE``() =
    Assert.IsTrue(Range("[7,11]").Equals(Range("(6,11]")))

[<Test>]
let ``Range("[14,24]").Equals(Range("[14,24)")) returns FALSE``() =
    Assert.IsFalse(Range("[14,24]").Equals(Range("[14,24)")))