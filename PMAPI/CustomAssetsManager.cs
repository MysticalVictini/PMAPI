using MelonLoader;
using UnityEngine;

namespace PMAPI.CustomAssetsManager
{
    public static class CustomAssetsManager
    {
        static string currentDirectory = Directory.GetCurrentDirectory() + "/Resources";

        /// <summary>
        /// Makes a new 2D Texture and returns it with the image requested to be loaded.
        /// </summary>
        /// <param name="resourceName">Name of the file. ex: fire.jpeg</param>
        /// <returns>New Texture with the requested image or blank if it didn't find the image.</returns>
        public static Texture2D LoadEmbeddedResource(string resourceName)
        {
            if (!Directory.Exists(currentDirectory) || !File.Exists(currentDirectory + "/" + resourceName))
            {
                MelonLogger.Msg("missing resource");
                return new Texture2D(2, 2);
            }

            Texture2D texture = new Texture2D(2, 2);
            byte[] bytes = File.ReadAllBytes(currentDirectory + "/" + resourceName);
            texture.LoadImage(bytes);
            texture.name = resourceName;
            return texture;
        }

        /// <summary>
        /// This method is meant to be called whenever a new part is initialized, this will adjust the texture to match the biggest side on the cube.
        /// Without calling this the texture might not be sized correctly
        /// </summary>
        /// <param name="part">this.transform or transform</param>
        public static void fixTexture(Transform part)
        {
            Material mat = part.GetComponent<MeshRenderer>().material;
            float biggest = 0;
            if (part.localScale.x > biggest)
            {
                biggest = part.localScale.x;
            }
            if (part.localScale.y > biggest)
            {
                biggest = part.localScale.y;
            }
            if (part.localScale.x > biggest)
            {
                biggest = part.localScale.y;
            }
            mat.mainTextureScale = new Vector2(2.5f, 2.5f) / biggest;
        }
    }

}
