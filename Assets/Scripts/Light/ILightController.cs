using System.Collections;

namespace Light
{
    public interface ILightController
    {
        void FlickAllExternalLights();
        void FlickLanternLight();
    }
}
