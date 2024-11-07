<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPage.Master" AutoEventWireup="true" CodeBehind="AdminLandingPage.aspx.cs" Inherits="GroceryApp.AdminLandingPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main id="main" class="main">
     <section>
     <div class="container h-100">
         <div class="row d-flex justify-content-center align-items-center h-100">
              <h1>Statistics</h1>
             <nav>
             <ol class="breadcrumb">
                 <li class="breadcrumb-item"><a href="adminMainMenu.aspx">Home</a></li>
                 <li class="breadcrumb-item active">Statistics</li>
             </ol>
             </nav>
             <section class="py-3 py-md-5">
  <div class="container">
    <div class="row justify-content-center">
      <div class="col-12 col-lg-10 col-xl-8 col-xxl-7">
        <div class="row gy-4">
          <div class="col-12 col-sm-6">
            <div class="card widget-card border-light shadow-sm">
              <div class="card-body p-4">
                <div class="row">
                  <div class="col-8">
                    <h5 class="card-title widget-card-title mb-3">Sales</h5>
                    <h4 class="card-subtitle text-body-secondary m-0" runat="server" id="sales">RM</h4>
                  </div>
                  <div class="col-4">
                    <div class="d-flex justify-content-end">
                      <div class="lh-1 text-white bg-info rounded-circle p-3 d-flex align-items-center justify-content-center">
                        <i class="bi bi-truck fs-4"></i>
                      </div>
                    </div>
                  </div>
                </div>
                <div class="row">
                  <div class="col-12">
                    <div class="d-flex align-items-center mt-3">
                      <span class="lh-1 me-3 bg-danger-subtle text-danger rounded-circle p-1 d-flex align-items-center justify-content-center">
                        <i class="bi bi-arrow-right-short bsb-rotate-45"></i>
                      </span>
                      <div>
                        <p class="fs-7 mb-0">-9%</p>
                        <p class="fs-7 mb-0 text-secondary">since last week</p>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
          <div class="col-12 col-sm-6">
            <div class="card widget-card border-light shadow-sm">
              <div class="card-body p-4">
                <div class="row">
                  <div class="col-8">
                    <h5 class="card-title widget-card-title mb-3">Earnings</h5>
                    <h4 class="card-subtitle text-body-secondary m-0" runat="server" id="profit">RM</h4>
                  </div>
                  <div class="col-4">
                    <div class="d-flex justify-content-end">
                      <div class="lh-1 text-white bg-info rounded-circle p-3 d-flex align-items-center justify-content-center">
                        <i class="bi bi-currency-dollar fs-4"></i>
                      </div>
                    </div>
                  </div>
                </div>
                <div class="row">
                  <div class="col-12">
                    <div class="d-flex align-items-center mt-3">
                      <span class="lh-1 me-3 bg-success-subtle text-success rounded-circle p-1 d-flex align-items-center justify-content-center">
                        <i class="bi bi-arrow-right-short bsb-rotate-n45"></i>
                      </span>
                      <div>
                        <p class="fs-7 mb-0">+26%</p>
                        <p class="fs-7 mb-0 text-secondary">since last week</p>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
          <div class="col-12 col-sm-6">
            <div class="card widget-card border-light shadow-sm">
              <div class="card-body p-4">
                <div class="row">
                  <div class="col-8">
                    <h5 class="card-title widget-card-title mb-3">Registered</h5>
                    <h4 class="card-subtitle text-body-secondary m-0" runat="server" id="registed"></h4>
                  </div>
                  <div class="col-4">
                    <div class="d-flex justify-content-end">
                      <div class="lh-1 text-white bg-info rounded-circle p-3 d-flex align-items-center justify-content-center">
                        <i class="bi bi-person fs-4"></i>
                      </div>
                    </div>
                  </div>
                </div>
                <div class="row">
                  <div class="col-12">
                    <div class="d-flex align-items-center mt-3">
                      <span class="lh-1 me-3 bg-success-subtle text-success rounded-circle p-1 d-flex align-items-center justify-content-center">
                        <i class="bi bi-arrow-right-short bsb-rotate-n45"></i>
                      </span>
                      <div>
                        <p class="fs-7 mb-0">+69%</p>
                        <p class="fs-7 mb-0 text-secondary">since last week</p>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
          <div class="col-12 col-sm-6">
            <div class="card widget-card border-light shadow-sm">
              <div class="card-body p-4">
                <div class="row">
                  <div class="col-8">
                    <h5 class="card-title widget-card-title mb-3">Orders</h5>
                    <h4 class="card-subtitle text-body-secondary m-0" runat="server" id="orders"></h4>
                  </div>
                  <div class="col-4">
                    <div class="d-flex justify-content-end">
                      <div class="lh-1 text-white bg-info rounded-circle p-3 d-flex align-items-center justify-content-center">
                        <i class="bi bi-cart fs-4"></i>
                      </div>
                    </div>
                  </div>
                </div>
                <div class="row">
                  <div class="col-12">
                    <div class="d-flex align-items-center mt-3">
                      <span class="lh-1 me-3 bg-danger-subtle text-danger rounded-circle p-1 d-flex align-items-center justify-content-center">
                        <i class="bi bi-arrow-right-short bsb-rotate-45"></i>
                      </span>
                      <div>
                        <p class="fs-7 mb-0">-21%</p>
                        <p class="fs-7 mb-0 text-secondary">since last week</p>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</section>
             <div class="col-xl-8 col-lg-7">
                 <div class="card shadow mb-4">
                     <div class="card-body">
                         <h5 class="card-title">Reports <span>/Today</span></h5>

                             <!-- Line Chart -->
                             <div id="reportsChart"></div>
                     <div class="card-header py-3">
                         <h6 class="m-0 font-weight-bold text-primary">Total Number Of Users Who Updated their Address</h6>
                     </div>
                     <div class="card-body">
                         <div class="chart-bar">
                             <canvas id="myBarChart"></canvas>
                         </div>
                     </div>
                     <div class="card-header py-3">
                         <h6 class="m-0 font-weight-bold text-primary">Total Number Of Users Who Updated their Account Data</h6>
                     </div>
                     <div class="card-body">
                         <div class="chart-bar">
                             <canvas id="myBarrt"></canvas>
                         </div>
                     </div>
                     <div class="card-header py-3">
                         <h6 class="m-0 font-weight-bold text-primary">Total Number Of Users Who Registered</h6>
                     </div>
                     <div class="card-body">
                         <div class="chart-bar">
                             <canvas id="myBarrt2"></canvas>
                         </div>
                     </div>
                 </div>
             </div>
         </div>
             </div>
     </div>
 </section>
        </main>

 <script>
     // Set new default font family and font color to mimic Bootstrap's default styling
     Chart.defaults.global.defaultFontFamily = 'Nunito', '-apple-system,system-ui,BlinkMacSystemFont,"Segoe UI",Roboto,"Helvetica Neue",Arial,sans-serif';
     Chart.defaults.global.defaultFontColor = '#858796';

     function number_format(number, decimals, dec_point, thousands_sep) {
         // *     example: number_format(1234.56, 2, ',', ' ');
         // *     return: '1 234,56'
         number = (number + '').replace(',', '').replace(' ', '');
         var n = !isFinite(+number) ? 0 : +number,
             prec = !isFinite(+decimals) ? 0 : Math.abs(decimals),
             sep = (typeof thousands_sep === 'undefined') ? ',' : thousands_sep,
             dec = (typeof dec_point === 'undefined') ? '.' : dec_point,
             s = '',
             toFixedFix = function (n, prec) {
                 var k = Math.pow(10, prec);
                 return '' + Math.round(n * k) / k;
             };
         // Fix for IE parseFloat(0.55).toFixed(0) = 0;
         s = (prec ? toFixedFix(n, prec) : '' + Math.round(n)).split('.');
         if (s[0].length > 3) {
             s[0] = s[0].replace(/\B(?=(?:\d{3})+(?!\d))/g, sep);
         }
         if ((s[1] || '').length < prec) {
             s[1] = s[1] || '';
             s[1] += new Array(prec - s[1].length + 1).join('0');
         }
         return s.join(dec);
     }
     var chartLabel;
     var chartDat;
     var chartLabel2;
     var chartDat2;
     var chartLabels;
     var chartData;
     var charCurrentDate;

     </script>

 <asp:Literal runat="server" ID="ltChartData"></asp:Literal>
 <asp:Literal runat="server" ID="Literal1"></asp:Literal>
 <asp:Literal runat="server" ID="Literal2"></asp:Literal>

 <script>
     // Bar Chart Example
     var ctx = document.getElementById("myBarChart");
     var myBarChart = new Chart(ctx, {
         type: 'bar',
         data: {
             labels: chartLabels,
             datasets: [{
                 label: "Views",
                 backgroundColor: "#4e73df",
                 hoverBackgroundColor: "#2e59d9",
                 borderColor: "#4e73df",
                 data: chartData,
             }],
         },
         options: {
             maintainAspectRatio: false,
             layout: {
                 padding: {
                     left: 10,
                     right: 25,
                     top: 25,
                     bottom: 0
                 }
             },
             scales: {
                 xAxes: [{
                     time: {
                         unit: 'month'
                     },
                     gridLines: {
                         display: false,
                         drawBorder: false
                     },
                     ticks: {
                         maxTicksLimit: 6
                     },
                     maxBarThickness: 25,
                 }],
                 yAxes: [{
                     ticks: {
                         min: 0,
                         max: 100,
                         maxTicksLimit: 5,
                         padding: 10,
                         // Include a dollar sign in the ticks
                         callback: function (value, index, values) {
                             return '' + number_format(value);
                         }
                     },
                     gridLines: {
                         color: "rgb(234, 236, 244)",
                         zeroLineColor: "rgb(234, 236, 244)",
                         drawBorder: false,
                         borderDash: [2],
                         zeroLineBorderDash: [2]
                     }
                 }],
             },
             legend: {
                 display: false
             },
             tooltips: {
                 titleMarginBottom: 10,
                 titleFontColor: '#6e707e',
                 titleFontSize: 14,
                 backgroundColor: "rgb(255,255,255)",
                 bodyFontColor: "#858796",
                 borderColor: '#dddfeb',
                 borderWidth: 1,
                 xPadding: 15,
                 yPadding: 15,
                 displayColors: false,
                 caretPadding: 10,
                 callbacks: {
                     label: function (tooltipItem, chart) {
                         var datasetLabel = chart.datasets[tooltipItem.datasetIndex].label || '';
                         return datasetLabel + ': ' + number_format(tooltipItem.yLabel);
                     }
                 }
             },
         }
     });

     var ctxer = document.getElementById("myBarrt");
     var myBarrt = new Chart(ctxer, {
         type: 'bar',
         data: {
             labels: chartLabel2,
             datasets: [{
                 label: "Logged In",
                 backgroundColor: "#4e73df",
                 hoverBackgroundColor: "#2e59d9",
                 borderColor: "#4e73df",
                 data: chartDat2,
             }],
         },
         options: {
             maintainAspectRatio: false,
             layout: {
                 padding: {
                     left: 10,
                     right: 25,
                     top: 25,
                     bottom: 0
                 }
             },
             scales: {
                 xAxes: [{
                     time: {
                         unit: 'month'
                     },
                     gridLines: {
                         display: false,
                         drawBorder: false
                     },
                     ticks: {
                         maxTicksLimit: 6
                     },
                     maxBarThickness: 25,
                 }],
                 yAxes: [{
                     ticks: {
                         min: 0,
                         max: 100,
                         maxTicksLimit: 5,
                         padding: 10,
                         // Include a dollar sign in the ticks
                         callback: function (value, index, values) {
                             return '' + number_format(value);
                         }
                     },
                     gridLines: {
                         color: "rgb(234, 236, 244)",
                         zeroLineColor: "rgb(234, 236, 244)",
                         drawBorder: false,
                         borderDash: [2],
                         zeroLineBorderDash: [2]
                     }
                 }],
             },
             legend: {
                 display: false
             },
             tooltips: {
                 titleMarginBottom: 10,
                 titleFontColor: '#6e707e',
                 titleFontSize: 14,
                 backgroundColor: "rgb(255,255,255)",
                 bodyFontColor: "#858796",
                 borderColor: '#dddfeb',
                 borderWidth: 1,
                 xPadding: 15,
                 yPadding: 15,
                 displayColors: false,
                 caretPadding: 10,
                 callbacks: {
                     label: function (tooltipItem, chart) {
                         var datasetLabel = chart.datasets[tooltipItem.datasetIndex].label || '';
                         return datasetLabel + ': ' + number_format(tooltipItem.yLabel);
                     }
                 }
             },
         }
     });

     var ctxer2 = document.getElementById("myBarrt2");
     var myBarrt2 = new Chart(ctxer2, {
         type: 'bar',
         data: {
             labels: chartLabel,
             datasets: [{
                 label: "Registered",
                 backgroundColor: "#4e73df",
                 hoverBackgroundColor: "#2e59d9",
                 borderColor: "#4e73df",
                 data: chartDat,
             }],
         },
         options: {
             maintainAspectRatio: false,
             layout: {
                 padding: {
                     left: 10,
                     right: 25,
                     top: 25,
                     bottom: 0
                 }
             },
             scales: {
                 xAxes: [{
                     time: {
                         unit: 'month'
                     },
                     gridLines: {
                         display: false,
                         drawBorder: false
                     },
                     ticks: {
                         maxTicksLimit: 6
                     },
                     maxBarThickness: 25,
                 }],
                 yAxes: [{
                     ticks: {
                         min: 0,
                         max: 20,
                         maxTicksLimit: 5,
                         padding: 10,
                         // Include a dollar sign in the ticks
                         callback: function (value, index, values) {
                             return '' + number_format(value);
                         }
                     },
                     gridLines: {
                         color: "rgb(234, 236, 244)",
                         zeroLineColor: "rgb(234, 236, 244)",
                         drawBorder: false,
                         borderDash: [2],
                         zeroLineBorderDash: [2]
                     }
                 }],
             },
             legend: {
                 display: false
             },
             tooltips: {
                 titleMarginBottom: 10,
                 titleFontColor: '#6e707e',
                 titleFontSize: 14,
                 backgroundColor: "rgb(255,255,255)",
                 bodyFontColor: "#858796",
                 borderColor: '#dddfeb',
                 borderWidth: 1,
                 xPadding: 15,
                 yPadding: 15,
                 displayColors: false,
                 caretPadding: 10,
                 callbacks: {
                     label: function (tooltipItem, chart) {
                         var datasetLabel = chart.datasets[tooltipItem.datasetIndex].label || '';
                         return datasetLabel + ': ' + number_format(tooltipItem.yLabel);
                     }
                 }
             },
         }
     });

     document.addEventListener("DOMContentLoaded", () => {
         new ApexCharts(document.querySelector("#reportsChart"), {
             series: [{
                 name: 'Address Updated',
                 data: chartData,
             }, {
                 name: 'Account Data Updated',
                 data: chartDat2,
             }, {
                 name: 'Users Who Registered',
                 data: chartDat,
             }],
             chart: {
                 height: 350,
                 type: 'area',
                 toolbar: {
                     show: false
                 },
             },
             markers: {
                 size: 4
             },
             colors: ['#4154f1', '#2eca6a', '#ff771d'],
             fill: {
                 type: "gradient",
                 gradient: {
                     shadeIntensity: 1,
                     opacityFrom: 0.3,
                     opacityTo: 0.4,
                     stops: [0, 90, 100]
                 }
             },
             dataLabels: {
                 enabled: false
             },
             stroke: {
                 curve: 'smooth',
                 width: 2
             },
             xaxis: {
                 type: 'date',
                 categories: chartLabel
             },
             tooltip: {
                 x: {
                     format: 'MM/yyyy'
                 },
             }
         }).render();
     });
 </script>
    <script src="assets/vendor/apexcharts/apexcharts.min.js"></script>
    <script src="assets/vendor/bootstrap/js/bootstrap.bundle.min.js"></script>
    <script src="assets/vendor/chart.js/chart.umd.js"></script>
    <script src="assets/vendor/echarts/echarts.min.js"></script>
    <script src="assets/vendor/quill/quill.min.js"></script>
    <script src="assets/vendor/simple-datatables/simple-datatables.js"></script>
    <script src="assets/vendor/tinymce/tinymce.min.js"></script>
    <script src="assets/js/chartMain.js"></script>
</asp:Content>
