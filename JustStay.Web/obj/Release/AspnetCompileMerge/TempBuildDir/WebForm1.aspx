<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="JustStay.Web.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        *, :before, :after {
            box-sizing: border-box;
            margin: 0;
            padding: 0;
        }

        #spin_wrapper {
            position: fixed;
            top: 50%;
            left: 50%;
            width: 300px;
            height: 300px;
            margin-top: -150px;
            margin-left: -150px;
            border-radius: 50%;
            background: #ffffff;
            border: 2px solid #ffffff;
            box-shadow: 0px 2px 5px 1px rgba(0,0,0, 0.3);
            &:after

        {
            content: '';
            position: absolute;
            left: 50%;
            bottom: 100%;
            width: 14px;
            height: 30px;
            margin-left: -7px;
            margin-bottom: -5px;
            border-style: solid;
            border-color: transparent;
            border-width: 7px;
            border-bottom: 0px;
            border-top: 30px solid #FFA514;
        }

        }

        #spin {
            transform-origin: 50% 50%;
        }
    </style>
</head>
<body>
   <%-- <label>Note: First add 60 the 180 and then 300 in the textbox and then click spin button.</label><br />
    <input type="text" id="txtslotvalue" /><br />
     <button id="start">Spin</button>
    <button id="stop">Stop</button>
    <div id="spin_wrapper">
        <svg xmlns="http://www.w3.org/2000/svg" id="spin" width="100%" height="100%" viewBox="0 0 100 100"></svg>
    </div>
    <script src="https://code.jquery.com/jquery-3.1.1.js"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.5/jquery-ui.min.js"></script>
    <script>
        window.requestAnimFrame = (function () {
            return window.requestAnimationFrame ||
                window.webkitRequestAnimationFrame ||
                window.mozRequestAnimationFrame ||
                function (callback) { window.setTimeout(callback, 1000 / 60); };
        })();


        function polarToCartesian(centerX, centerY, radius, angleInDegrees) {
            var angleInRadians = (angleInDegrees - 90) * Math.PI / 180.0;
            return {
                x: centerX + (radius * Math.cos(angleInRadians)),
                y: centerY + (radius * Math.sin(angleInRadians))
            };
        }
        function arcPath(x, y, radius, endradius, startAngle, endAngle) {
            var start = polarToCartesian(x, y, radius, endAngle);
            var end = polarToCartesian(x, y, radius, startAngle);
            var start2 = polarToCartesian(x, y, endradius, endAngle);
            var end2 = polarToCartesian(x, y, endradius, startAngle);
            var largeArcFlag = endAngle - startAngle <= 180 ? "0" : "1";
            var d = [
                "M", start.x, start.y,
                "A", radius, radius, 0, largeArcFlag, 0, end.x, end.y,
                "L", end2.x, end2.y,
                "A", endradius, endradius, 0, largeArcFlag, 1, start2.x, start2.y,
                "Z"
            ].join(" ");
            return d;
        }

        var spin = {
            slots: [
                { value: 'Rs.100', color: '#7CB247',id:'1' },
                { value: 'Loss1', color: '#000000', id:'2' },
                { value: 'Rs.1000', color: '#7CB247', id:'3' },
                { value: 'Loss2', color: '#000000', id:'4' },
                { value: 'Rs.10000', color: '#7CB247', id:'5' },
                { value: 'Loss3', color: '#000000',id:'6' },
            ],
            speed: 0,
            spinSpeed: 10,
            degree: 0,
            obj: null,
            stop: false,
            min_duration: 3000,
            max_duration: 8000,
            rand_speed: 0,
        };

        var spin_anim = function () {
            if (spin.stop) { return true; }
            spin.degree = filter_degree(spin.degree + spin.speed);
            spin.obj.css('transform', 'rotate(' + spin.degree + 'deg)');
            requestAnimFrame(spin_anim);
        };

        function filter_degree(d) {
          ///  alert(d);
            while (d < 0) {
                d += 360;
            }
            return (d % 360);
        }

        function spin_start() {
            spin.stop = false;
            spin_anim();
            spin.rand_speed = Math.random();
            $(spin).animate({ speed: spin.spinSpeed }, 0.15 * spin.min_duration, "easeInBack", function () {
                $(spin).animate({ speed: 0 }, (spin.min_duration + (spin.max_duration - spin.min_duration) * spin.rand_speed), "easeOutSine", function () {
                    spin_stop();
                });
            });
        }

        function spin_stop() {
            spin.stop = true;
            var values = spin.obj.css('transform'),
                values = values.split('(')[1],
                values = values.split(')')[0],
                values = values.split(',');
           // alert(values);
           // alert(values[0]);
           // alert(values[1]);
           // var d = filter_degree(Math.atan2(values[1], values[0]) * (180 / Math.PI));
           
           // alert(Math.PI);
            var p = (360 / spin.slots.length);
           // alert(p);
            //d = 60, 180, 300;
            var d = $('#txtslotvalue').val();
            var slot = Math.floor((360 - d) / p);
           // alert(slot);
            console.log(d + ' => slot #' + slot + ' => ' + spin.slots[slot].value);
            alert(spin.slots[slot].value);
        }

        $(document).ready(function () {
            spin.obj = $('#spin');

            var slot_count = spin.slots.length;
            var svg = '';
            var t = 0;
            for (var i = 0; i < slot_count; i++) {
                t = polarToCartesian(50, 50, 45, ((i + 0.5) * (360 / slot_count)));
                svg = svg + '<path d="' + arcPath(50, 50, 5, 50, (i * (360 / slot_count)), ((i + 1) * (360 / slot_count))) + '" fill="' + spin.slots[i].color + '" stroke="#ffffff" stroke-width="0" />';
                svg = svg + '<text font-size="6" x="' + t.x + '" y="' + t.y + '" fill="#000000" font-style="bold" font-family="Arial" alignment-baseline="central" text-anchor="middle" transform="rotate(' + (1 * ((i + 0.5) * (360 / slot_count))) + ' ' + t.x + ',' + t.y + ')" stroke="#000000" stroke-width="1" opacity="0.3">' + spin.slots[i].value + '</text>';
                svg = svg + '<text font-size="6" x="' + t.x + '" y="' + t.y + '" fill="#ffffff" font-style="bold" font-family="Arial" alignment-baseline="central" text-anchor="middle" transform="rotate(' + (1 * ((i + 0.5) * (360 / slot_count))) + ' ' + t.x + ',' + t.y + ')">' + spin.slots[i].value + '</text>';
            }
            $('#spin').html(svg);

            spin.degree = Math.random() * 360;
            //alert(spin.degree);
            spin.obj.css('transform', 'rotate(' + spin.degree + 'deg)');

            $('#start').click(function (e) {
                e.preventDefault();
                spin_start();
            });
            $('#stop').click(function (e) {
                e.preventDefault();
                spin_stop();
            });
        });
    </script> --%>
</body>
</html>
