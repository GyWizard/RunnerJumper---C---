namespace RunnerJumper
{
    using UnityEngine.SceneManagement;
    using UnityEngine.UI;
    public sealed class RestartManager
    {
        
        public void Restart()
        {
            SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex); // Перезапускаем сцену
        }

    }
}

