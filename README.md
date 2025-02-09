# Primitier modding API
## Setting up
1. Install **LATEST** [MelonLoader](https://github.com/LavaGang/MelonLoader/releases/latest)
2. Run it once
3. Create a system environment variable ```PRIMITIER_DIR``` and set it to your Primitier folder path
4. Clone the project and open it in visual studio
5. Try building TestMod to ensure that everything is working
6. Every system is demonstrated in TestMod so you can understand them




Victini's Addition: custom textures! (Images need to be in a folder called Resources in the same directory as Mods)
<image href="https://i.gyazo.com/a0e9d7211cc14e5427707d8f5d5434d1.png" />
When initializing a material you can set the mainTexture to the return of LoadEmbeddedResource in CustomAssetsManager.

Ex of usage: Texture texture = CustomAssetsManager.LoadEmbeddedResource("laser.png");

Material cmat = new(SubstanceManager.GetMaterial("Glass"))
{
    name = "Laser",//Sets the name of the material to Laser
    color = new UnityEngine.Color(1,1,1,0.6f),//Sets the color of the material to white and have an alpha of 0.6 ( makes it transparent)
    mainTexture = texture//Sets the texture of the cube to texture.
};


inside of the behaviour script on initialization make sure to call the fixTexture method.


void OnInitialize()
{
    cubeBase = GetComponent<CubeBase>();
    CustomAssetsManager.fixTexture(this.transform);
}


**Full documentation is TBD**
