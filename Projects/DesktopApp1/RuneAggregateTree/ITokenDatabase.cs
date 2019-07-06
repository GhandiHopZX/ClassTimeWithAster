using System.Collections.Generic;

namespace RuneAggregateTree
{
    public interface ITokenDatabase
    {
        /// <summary>Adds a new game.</summary>
        /// <param name="token">The game to add.</param>
        /// <returns>The new game.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="token"/> is null.</exception>
        /// <exception cref="ValidationException"><paramref name="token"/> is invalid.</exception>
        /// <exception cref="ArgumentException">A game with the same name already exists.</exception>
        Token Add(Token token);

      /// <summary>Deletes a game.</summary>
      /// <param name="id">The ID of the game.</param>
      /// <exception cref="ArgumentOutOfRangeException"><paramref name="id"/> is less than or equal to 0.</exception>
      void Delete(int id);

      /// <summary>Gets a game.</summary>
      /// <param name="id">The ID of the game.</param>
      /// <returns>The game, if any.</returns>
      /// <exception cref="ArgumentOutOfRangeException"><paramref name="id"/> is less than or equal to 0.</exception>
      Token Get(int id);

      /// <summary>Gets all games.</summary>
      /// <returns>The list of games.</returns>
      IEnumerable<Token> GetAll();

      /// <summary>Updates an existing game.</summary>
      /// <param name="id">The ID of the existing game.</param>
      /// <param name="token">The game to add.</param>
      /// <returns>The updated game.</returns>
      /// <exception cref="ArgumentNullException"><paramref name="token"/> is null.</exception>
      /// <exception cref="ArgumentOutOfRangeException"><paramref name="id"/> is less than or equal to 0.</exception>
      /// <exception cref="ArgumentException">The game does not exist.
      /// <para>-or-</para>
      /// A game with the same name already exists.
      /// </exception>
      /// <exception cref="ValidationException"><paramref name="token"/> is invalid.</exception>
      Token Update(int id, Token token);    }
}
