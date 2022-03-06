module Poker.VideoPoker

open Poker.Cards

let deal (deck: 'a list) = deck[..4], deck[5..]

let hold hand held deck =
    let drawn = deck |> List.take((hand |> List.length) - (held |> List.length))
    (Set.union (Set.ofList held) (Set.ofList drawn)) |> Set.toList

let newGame = sortedDeck |> shuffle |> deal