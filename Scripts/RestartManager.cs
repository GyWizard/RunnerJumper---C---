namespace RunnerJumper
{
    using UnityEngine.SceneManagement;
    public class RestartManager
    {
        public void Restart()
        {
            SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex);
        }
    }

}

