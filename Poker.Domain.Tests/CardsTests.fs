module Poker.Cards.Tests

open NUnit.Framework

open Poker.Cards

let highCards = [
    ["AC";"JH";"3D";"KC";"5C"];
    ["AC";"2H";"3D";"4C";"6C"];
    ["2H";"7S";"9H";"3H";"JH"];
    ["2D";"KS";"QS";"JS";"10S"];
]
[<TestCaseSource("highCards")>]
let HighCard (cards: string list) =
    match handToRank (cards |> List.map CreateCard) with
    | HighCard -> Assert.Pass()
    | x -> Assert.Fail(x.ToString())

let pairs = [
    ["AC";"JH";"3D";"AC";"5C"];
    ["7H";"KC";"9C";"6C";"KD"];
    ["10S";"2H";"9S";"2S";"5S"];
    ["AD";"JD";"4D";"KD";"4C"];
]
[<TestCaseSource("pairs")>]
let Pair (cards: string list) =
    match handToRank (cards |> List.map CreateCard) with
    | Pair -> Assert.Pass()
    | x -> Assert.Fail(x.ToString())

let threeOfAKinds = [
    ["AC";"AH";"3D";"AC";"5C"];
    ["KH";"KC";"9C";"6C";"KD"];
    ["10S";"2H";"2S";"2S";"5S"];
    ["4D";"JD";"4D";"KD";"4C"];
]
[<TestCaseSource("threeOfAKinds")>]
let ThreeOfAKind (cards: string list) =
    match handToRank (cards |> List.map CreateCard) with
    | ThreeOfAKind -> Assert.Pass()
    | x -> Assert.Fail(x.ToString())

let straights = [
    ["AC";"2H";"3D";"4C";"5C"];
    ["5H";"7C";"9C";"6C";"8D"];
    ["2S";"4H";"3S";"6S";"5S"];
    ["10D";"JD";"QD";"KD";"AC"];
]
[<TestCaseSource("straights")>]
let Straight (cards: string list) =
    match handToRank (cards |> List.map CreateCard) with
    | Straight -> Assert.Pass()
    | x -> Assert.Fail(x.ToString())

let flushes = [
    ["2C";"7C";"9C";"3C";"JC"];
    ["2H";"7H";"9H";"3H";"JH"];
    ["2S";"7S";"9S";"3S";"JS"];
    ["2D";"7D";"9D";"3D";"JD"];
]
[<TestCaseSource("flushes")>]
let Flush (cards: string list) =
    match handToRank (cards |> List.map CreateCard) with
    | Flush -> Assert.Pass()
    | x -> Assert.Fail(x.ToString())

let fullHouses = [
    ["KC";"KD";"KS";"2H";"2C"];
    ["8C";"8D";"8S";"AH";"AC"];
    ["9C";"AD";"AS";"9H";"9C"];
    ["8C";"10D";"8S";"10H";"8C"];
]
[<TestCaseSource("fullHouses")>]
let FullHouse (cards: string list) =
    match handToRank (cards |> List.map CreateCard) with
    | FullHouse -> Assert.Pass()
    | x -> Assert.Fail(x.ToString())

let fourOfAKinds = [
    ["KC";"KD";"KS";"KH";"9C"];
    ["2C";"2D";"2S";"2H";"5C"];
    ["KC";"7D";"7S";"7H";"7C"];
    ["10C";"10D";"10S";"KH";"10C"];
]
[<TestCaseSource("fourOfAKinds")>]
let FourOfAKind (cards: string list) =
    match handToRank (cards |> List.map CreateCard) with
    | FourOfAKind -> Assert.Pass()
    | x -> Assert.Fail(x.ToString())

let straightFlushes = [
    ["KC";"QC";"JC";"10C";"9C"];
    ["JD";"10D";"9D";"8D";"7D"];
    ["AH";"2H";"3H";"4H";"5H"];
    ["2S";"3S";"4S";"5S";"6S"];
]
[<TestCaseSource("straightFlushes")>]
let StraightFlush (cards: string list) =
    match handToRank (cards |> List.map CreateCard) with
    | StraightFlush -> Assert.Pass()
    | x -> Assert.Fail(x.ToString())

let royalFlushes = [
    ["AC";"KC";"QC";"JC";"10C"];
    ["AD";"KD";"QD";"JD";"10D"];
    ["AH";"KH";"QH";"JH";"10H"];
    ["AS";"KS";"QS";"JS";"10S"];
]
[<TestCaseSource("royalFlushes")>]
let RoyalFlush (cards: string list) =
    match handToRank (cards |> List.map CreateCard) with
    | RoyalFlush -> Assert.Pass()
    | x -> Assert.Fail(x.ToString())