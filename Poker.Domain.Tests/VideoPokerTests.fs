module Poker.Domain.Tests

open NUnit.Framework

open Poker.VideoPoker

[<Test>]
let HandHasFiveCards () =
    let (hand, _) = newGame
    Assert.AreEqual(5, hand |> List.length)

[<Test>]
let DeckHas47Cards () =
    let (_, deck) = newGame
    Assert.AreEqual(47, deck |> List.length)

[<Test>]
let CardsAreNotInBothHandAndDeck () =
    let (hand, deck) = newGame
    let intersect = Set.intersect (Set.ofList hand) (Set.ofList deck)
    Assert.AreEqual(0, intersect.Count)

[<Test>]
let HoldNoneDealsFiveNewCards () =
    let (hand, deck) = newGame
    let newHand = hold hand [] deck
    let intersect = Set.intersect (Set.ofList newHand) (Set.ofList hand)
    Assert.AreEqual(0, intersect.Count)

[<Test>]
let HoldNoneDealsFiveDifferentCards () =
    let (hand, deck) = newGame
    let newHand = hold hand [] deck
    let distinct = newHand |> List.distinct |> List.length
    Assert.AreEqual(5, distinct)

[<Test>]
let HoldAllKeepsHand () =
    let (hand, deck) = newGame
    let newHand = hold hand hand deck
    let intersect = Set.intersect (Set.ofList newHand) (Set.ofList hand)
    Assert.AreEqual(5, intersect.Count)
