module Poker.Cards

open System

type Suit = Clubs | Diamonds | Hearts | Spades
type Face = Two | Three | Four | Five | Six | Seven | Eight | Nine | Ten | Jack | Queen | King | Ace

let allSuits = [Clubs; Diamonds; Hearts; Spades]
let allFaces = [Two; Three; Four; Five; Six; Seven; Eight; Nine; Ten; Jack; Queen; King; Ace]

type Card = { Face: Face; Suit: Suit }

let sortedDeck = [
    for suit in allSuits do
    for face in allFaces do
    yield { Face = face; Suit = suit }
]

let shuffle deck = deck |> List.sortBy (fun _ -> Guid.NewGuid())
