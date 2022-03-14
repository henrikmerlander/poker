module Poker.Cards

let print cards = cards |> List.iter (printfn "%A")

type Suit = 
    | Clubs
    | Diamonds
    | Hearts
    | Spades

let CreateSuit (s: string) =
    match s with
    | "C" -> Clubs
    | "D" -> Diamonds
    | "H" -> Hearts
    | "S" -> Spades
    | _ -> raise <| System.ArgumentOutOfRangeException()

type Face = 
    | Two
    | Three
    | Four
    | Five
    | Six
    | Seven
    | Eight
    | Nine
    | Ten
    | Jack
    | Queen
    | King
    | Ace

let CreateFace (s: string) =
    match s with
    | "2" -> Two
    | "3" -> Three
    | "4" -> Four
    | "5" -> Five
    | "6" -> Six
    | "7" -> Seven
    | "8" -> Eight
    | "9" -> Nine
    | "10" -> Ten
    | "J" -> Jack
    | "Q" -> Queen
    | "K" -> King
    | "A" -> Ace
    | _ -> raise <| System.ArgumentOutOfRangeException()

let faceToInt face =
    match face with
    | Two -> 2
    | Three -> 3
    | Four -> 4
    | Five -> 5
    | Six -> 6
    | Seven -> 7
    | Eight -> 8
    | Nine -> 9
    | Ten -> 10
    | Jack -> 11
    | Queen -> 12
    | King -> 13
    | Ace -> 14
    
type Card = { Face: Face; Suit: Suit }

let CreateCard (s: string) =
    let m = System.Text.RegularExpressions.Regex.Match(s, "([2-9]|10|[AKQJ])([CDHS])")
    { Face = CreateFace m.Groups.[1].Value; Suit = CreateSuit m.Groups.[2].Value}

type Hand = Hand of Card list

let CreateHand (l: Card list) =
    if List.length l = 5
        then Some (Hand l)
        else None

let allSuits = [Clubs; Diamonds; Hearts; Spades]
let allFaces = [Two; Three; Four; Five; Six; Seven; Eight; Nine; Ten; Jack; Queen; King; Ace]

let sortedDeck = [
    for suit in allSuits do
    for face in allFaces do
    yield { Face = face; Suit = suit }
]

let shuffle deck = deck |> List.sortBy (fun _ -> System.Guid.NewGuid())

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

        let isStraight =
            let cardsContainsFace = (fun x -> cards |> List.exists (fun y -> y.Face = x))
            let isWheel =
                [Ace; Two; Three; Four; Five]
                |> List.forall cardsContainsFace

            let facesAsInts =
                cards
                |> List.map (fun x -> faceToInt x.Face)

            let isStraight =
                facesAsInts
                |> List.map (fun x-> x - List.min facesAsInts)
                |> List.sum = 10

            isWheel || isStraight

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
        | (_, _, _, true, _, _, _, _) -> Straight
        | (_, _, true, _, _, _, _, _) -> ThreeOfAKind
        | (_, true, _, _, _, _, _, _) -> TwoPair
        | (true, _, _, _, _, _, _, _) -> Pair
        | _ -> HighCard
