module Poker.Cards.Tests

open NUnit.Framework

open Poker.Cards

[<Test>]
let HighCard () =
    let highCardHand = [
        { Face = King; Suit = Hearts };
        { Face = Two; Suit = Spades};
        { Face = Eight; Suit = Clubs };
        { Face = Jack; Suit = Diamonds };
        { Face = Six; Suit = Hearts };
    ]
    match handToRank highCardHand with
        | HighCard -> Assert.Pass()
        | x -> Assert.Fail(x.ToString())

[<Test>]
let Pair () =
    let pairHand = [
        { Face = King; Suit = Hearts };
        { Face = King; Suit = Spades};
        { Face = Eight; Suit = Clubs };
        { Face = Jack; Suit = Diamonds };
        { Face = Six; Suit = Hearts };
    ]
    match handToRank pairHand with
        | Pair -> Assert.Pass()
        | x -> Assert.Fail(x.ToString())

[<Test>]
let ThreeOfAKind () =
    let threeOfAKindHand = [
        { Face = King; Suit = Hearts };
        { Face = King; Suit = Spades};
        { Face = King; Suit = Clubs };
        { Face = Eight; Suit = Diamonds };
        { Face = Six; Suit = Hearts };
    ]
    match handToRank threeOfAKindHand with
        | ThreeOfAKind -> Assert.Pass()
        | x -> Assert.Fail(x.ToString())

[<Test>]
let Straight () =
    let straightHand = [
        { Face = Eight; Suit = Hearts };
        { Face = Seven; Suit = Spades};
        { Face = Six; Suit = Clubs };
        { Face = Five; Suit = Diamonds };
        { Face = Four; Suit = Hearts };
    ]
    match handToRank straightHand with
        | Straight -> Assert.Pass()
        | x -> Assert.Fail(x.ToString())

[<Test>]
let Flush () =
    let flushHand = [
        { Face = King; Suit = Hearts };
        { Face = Two; Suit = Hearts};
        { Face = Eight; Suit = Hearts };
        { Face = Jack; Suit = Hearts };
        { Face = Six; Suit = Hearts };
    ]
    match handToRank flushHand with
        | Flush -> Assert.Pass()
        | x -> Assert.Fail(x.ToString())

[<Test>]
let FullHouse () =
    let fullHouseHand = [
        { Face = King; Suit = Hearts };
        { Face = King; Suit = Spades };
        { Face = King; Suit = Clubs };
        { Face = Two; Suit = Hearts };
        { Face = Two; Suit = Spades };
    ]
    match handToRank fullHouseHand with
        | FullHouse -> Assert.Pass()
        | x -> Assert.Fail(x.ToString())

[<Test>]
let FourOfAKind () =
    let fourOfAKindHand = [
        { Face = King; Suit = Hearts };
        { Face = King; Suit = Spades };
        { Face = King; Suit = Clubs };
        { Face = King; Suit = Diamonds };
        { Face = Two; Suit = Spades };
    ]
    match handToRank fourOfAKindHand with
        | FourOfAKind -> Assert.Pass()
        | x -> Assert.Fail(x.ToString())

[<Test>]
let StraightFlush () =
    let straightFlushHand = [
        { Face = Eight; Suit = Hearts };
        { Face = Seven; Suit = Hearts};
        { Face = Six; Suit = Hearts };
        { Face = Five; Suit = Hearts };
        { Face = Four; Suit = Hearts };
    ]
    match handToRank straightFlushHand with
        | StraightFlush -> Assert.Pass()
        | x -> Assert.Fail(x.ToString())

[<Test>]
let RoyalFlush () =
    let royalFlushHand = [
        { Face = Ace; Suit = Hearts };
        { Face = King; Suit = Hearts};
        { Face = Queen; Suit = Hearts };
        { Face = Jack; Suit = Hearts };
        { Face = Ten; Suit = Hearts };
    ]
    match handToRank royalFlushHand with
        | RoyalFlush -> Assert.Pass()
        | x -> Assert.Fail(x.ToString())