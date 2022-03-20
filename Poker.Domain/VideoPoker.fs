module Poker.VideoPoker

open Poker.Cards

type BetSize = BetSize of int
type PayoutAmount = PayoutAmount of int

type BetData = { Deck: Card list }
type DealData = { BetSize: BetSize; Hand: Card list; Deck: Card list }
type DrawData = { PayoutAmount: PayoutAmount; Hand: Card list; Rank: Rank }

type Game =
    | Bet of BetData
    | Deal of DealData
    | Draw of DrawData

module Game =
    let create =
        Bet { Deck = sortedDeck |> shuffle }

    let deal game betSize =
        match game with
        | Bet { Deck = deck } ->
            Deal { BetSize = betSize; Hand = deck[..4]; Deck = deck[5..] }
        | Deal _ ->
            game
        | Draw _ ->
            game

    let hold game hold =
        match game with
        | Bet _ ->
            game
        | Deal { BetSize = _; Hand = hand; Deck = deck } ->
            let drawn = deck |> List.take(5 - (hold |> List.length))
            let held = 
                hand
                |> List.indexed
                |> List.filter (fun (i, _) -> hold |> List.contains i)
                |> List.map snd
            let newHand = held @ drawn
            Draw { PayoutAmount = PayoutAmount 0; Hand = newHand; Rank = handToRank newHand }
        | Draw _ ->
            game