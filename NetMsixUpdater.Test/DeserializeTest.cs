using Xunit;
using System.Reflection;

namespace NetMsixUpdater.Test
{
    public class DeserializeTest
    {
        [Fact]
        public void Deserialize()
        {
            MsixUpdater msixUpdater = new(Assembly.GetExecutingAssembly(), Consts.YAML_PATH);
            msixUpdater.Build();
        }
    }
}
