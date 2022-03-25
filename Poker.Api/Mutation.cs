namespace Poker.Api
{
    public class Mutation
    {
        public GamePayload CreateGame() => new GamePayload();

        public GamePayload Deal(DealInput input) => new GamePayload();

        public GamePayload Hold(HoldInput input) => new GamePayload();
    }
}
