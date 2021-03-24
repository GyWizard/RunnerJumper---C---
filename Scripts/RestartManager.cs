namespace RunnerJumper
{
    using UnityEngine.SceneManagement;
    public sealed class RestartManager
    {
        public void Restart()
        {
            SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex); // Перезапускаем сцену
        }
    }

}

