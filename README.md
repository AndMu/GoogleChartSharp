# Wikiled.Google.Chart

Nuget library

![nuget](https://img.shields.io/nuget/v/Wikiled.Google.Chart.svg)

GoogleChartSharp 
================

A C# wrapper for the Google Chart Images API.

This a fork of the original GoogleChartSharp wrapper, found at https://code.google.com/p/googlechartsharp/.

Compiled as .NetStandard 2.0 library and is published as nuget

Sample use code
```
int[] line1 = { 5, 10, 50, 34, 10, 25 };
int[] line2 = { 15, 20, 60, 44, 20, 35 };

List<int[]> dataset = new List<int[]>();
dataset.Add(line1);
dataset.Add(line2);

LineChart lineChart = new LineChart(250, 150);
lineChart.SetTitle("Single Dataset Per Line", "0000FF", 14);
lineChart.SetData(dataset);
lineChart.AddAxis(new ChartAxis(ChartAxisType.Bottom));
lineChart.AddAxis(new ChartAxis(ChartAxisType.Left));
var data = await instance.GetImage(lineChart).ConfigureAwait(false);
await File.WriteAllBytesAsync("image.jpg", data).ConfigureAwait(false);

```