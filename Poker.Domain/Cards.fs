module Poker.Cards

open System

let print cards = cards |> List.iter (printfn "%A")

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

type Rank =
    | HighCard
    | Pair
    | TwoPair
    | ThreeOfAKind
    | Straight
    | Flush
    | FullHouse
    | FourOfAKind
    | StraightFlush
    | RoyalFlush

type HandToRank = Card list -> Rank

let handToRank: HandToRank =
    fun cards ->
        let isPair =
            cards
            |> List.groupBy (fun x -> x.Face)
            |> List.exists (fun (_, value) -> List.length value = 2)

        let isTwoPair =
            cards
            |> List.groupBy (fun x -> x.Face)
            |> List.filter (fun (_, value) -> List.length value = 2)
            |> List.length = 2

        let isThreeOfAKind =
            cards
            |> List.groupBy (fun x -> x.Face)
            |> List.exists (fun (_, value) -> List.length value = 3)

        let isStraight = false

        let isFlush =
            cards
            |> List.filter (fun x -> x.Suit = (List.head cards).Suit)
            |> List.length = List.length cards

        let isFullHouse =
            let hasThreeOfAKind =
                cards
                |> List.groupBy (fun x -> x.Face)
                |> List.filter (fun (_, value) -> List.length value = 3)
                |> List.length = 1
            let hasPair =
                cards
                |> List.groupBy (fun x -> x.Face)
                |> List.filter (fun (_, value) -> List.length value = 2)
                |> List.length = 1
            hasThreeOfAKind && hasPair

        let isFourOfAKind =
            cards
            |> List.groupBy (fun x -> x.Face)
            |> List.exists (fun (_, value) -> List.length value = 4)

        let isRoyalFlush =
            let faces = 
                cards
                |> List.map (fun x -> x.Face)
            isFlush
            && (faces |> List.contains Ace)
            && (faces |> List.contains King)
            && (faces |> List.contains Queen)
            && (faces |> List.contains Jack)
            && (faces |> List.contains Ten)

        match isPair, isTwoPair, isThreeOfAKind, isStraight, isFlush, isFullHouse, isFourOfAKind, isRoyalFlush with
            | (_, _, _, _, _, _, _, true) -> RoyalFlush
            | (_, _, _, true, true, _, _, _) -> StraightFlush
            | (_, _, _, _, _, _, true, _) -> FourOfAKind
            | (_, _, _, _, _, true, _, _) -> FullHouse
            | (_, _, _, _, true, _, _, _) -> Flush
            | (_, _, true, _, _, _, _, _) -> ThreeOfAKind
            | (_, true, _, _, _, _, _, _) -> TwoPair
            | (true, _, _, _, _, _, _, _) -> Pair
            | _ -> HighCard