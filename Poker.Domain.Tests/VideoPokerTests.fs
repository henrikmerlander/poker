module Poker.Domain.Tests

open NUnit.Framework

open Poker.VideoPoker

[<Test>]
let deal () =
    let game = Game.create
    let afterDeal = Game.deal game (BetSize 0)
    match afterDeal with
    | Deal { BetSize = betSize; Hand = hand; Deck = deck; } ->
        Assert.AreEqual(BetSize 0, betSize)
        Assert.AreEqual(5, hand.Length)
        Assert.AreEqual(47, deck.Length)
    | _ -> Assert.Fail()

[<Test>]
let hold () =
    let game = Game.create
    let afterDeal = Game.deal game (BetSize 0)
    let afterHold = Game.hold afterDeal []
    match afterHold with
    | Draw { PayoutAmount = payoutAmount; Hand = hand; Rank = rank; } ->
        Assert.AreEqual(PayoutAmount 0, payoutAmount)
        Assert.AreEqual(5, hand.Length)
    | _ -> Assert.Fail()

[<Test>]
let fullGame () =
    let game = Game.create
    let afterDeal = Game.deal game (BetSize 0)
    let afterHold = Game.hold afterDeal [0; 1]
    printfn "%A" afterHold
    Assert.Pass()