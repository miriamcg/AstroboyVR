using Astroboy.Manager;

namespace Astroboy.Stats {

    public class PlayerStats : CharacterStats {

        private GameManager _gameManager;

        private void Start()
        {
            _gameManager = GameManager.Instance;
        }

        public override void Die() {
            _gameManager.GameLoose();
            base.Die();
        }
    }
}
