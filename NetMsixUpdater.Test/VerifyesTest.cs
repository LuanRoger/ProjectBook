using System.Reflection;
using Xunit;

namespace NetMsixUpdater.Test
{
    public class VerifyesTest
    {
        [Fact]
        public void VerifyUpdate()
        {
            MsixUpdater msixUpdater = new(Assembly.GetExecutingAssembly(), Consts.YAML_PATH);
            msixUpdater.Build();

            Assert.False(msixUpdater.hasUpdated);
        }
    }
}
