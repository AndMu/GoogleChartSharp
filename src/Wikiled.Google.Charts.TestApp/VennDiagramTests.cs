using Wikiled.Google.Chart;

namespace Wikiled.Google.Charts.TestApp
{
    class VennDiagramTests
    {
        public static string VennDiagramTest()
        {
            int[] data = { 100, 80, 60, 30, 30, 30, 10 };

            VennDiagram vennDiagram = new VennDiagram(150, 150);
            vennDiagram.SetTitle("Venn Diagram");
            vennDiagram.SetData(data);

            return vennDiagram.GetUrl();
        }
    }
}
