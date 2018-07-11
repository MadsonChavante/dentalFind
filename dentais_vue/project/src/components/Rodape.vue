<template>
<div>
<svg class="init c-icons__social">
  <symbol id="c-icons--facebook" viewBox="0 0 100 100">
    <path d="M94.5 0h-89C2.5 0 0 2.5 0 5.5v89c0 3 2.5 5.5 5.5 5.5h47.9V61.3h-13V46.2h13V35.1c0-12.9 7.9-19.9 19.4-19.9 5.5 0 10.3.4 11.6.6v13.5h-8c-6.3 0-7.5 3-7.5 7.3v9.6h14.9l-1.9 15.1h-13V100h25.6c3 0 5.5-2.5 5.5-5.5v-89c0-3-2.5-5.5-5.5-5.5z"></path>
  </symbol>
  <symbol id="c-icons--instagram" viewBox="0 0 100 100">
    <path d="M50 0c-6.77 0-13.54-.02-20.31.29-4.99.22-9.94 1.03-14.47 3.21-4.86 2.34-8.99 6.36-11.44 11.16C.33 21.4.19 29.04.06 36.44-.09 45.25-.07 54.08.05 62.9c.1 7.2.17 14.64 3.19 21.32 2.22 4.92 6.13 9.14 10.87 11.72 4.46 2.42 9.49 3.44 14.51 3.73 6.6.39 13.23.34 19.84.34 7.08 0 14.17.06 21.25-.26 4.78-.21 9.49-.84 13.93-2.73 4.98-2.12 9.28-5.89 11.99-10.58 3.91-6.77 4.15-14.63 4.3-22.24.17-8.79.13-17.59.03-26.38-.08-7-.06-14.27-2.7-20.86-2.02-5.04-5.65-9.41-10.29-12.26C82.72 2.09 77.77.87 72.84.45 66.26-.12 59.59.01 52.98 0H50c-13.58 0 0 0 0 0zm0 9.01c6.69 0 13.37-.02 20.05.29 4.31.2 8.84.88 12.53 3.28 3.87 2.52 6.3 6.51 7.33 10.95.78 3.35.84 6.83.95 10.26.1 3 .11 6 .12 9 .03 8.06.15 16.14-.15 24.2-.13 3.59-.23 7.23-1.25 10.71-1.33 4.54-4.3 8.52-8.6 10.62-5.77 2.83-12.66 2.55-18.96 2.62-8.67.1-17.35.14-26.01-.03-6.8-.13-14.56.04-20.06-4.59-6.31-5.3-6.63-13.3-6.84-20.92-.23-8.49-.14-16.99-.08-25.48.02-2.57.06-5.14.16-7.71.15-3.7.32-7.44 1.55-10.96 1.66-4.75 5.19-8.49 9.91-10.29 3.53-1.35 7.29-1.59 11.03-1.75 6.1-.25 12.21-.2 18.32-.2m0 57.66c-9.2 0-16.67-7.46-16.67-16.67S40.8 33.33 50 33.33c9.21 0 16.67 7.46 16.67 16.67S59.2 66.67 50 66.67zm0-42.35c-14.18 0-25.68 11.5-25.68 25.68S35.82 75.68 50 75.68 75.68 64.18 75.68 50 64.18 24.32 50 24.32m32.69-1.01c0 3.31-2.69 6-6 6s-6-2.69-6-6 2.69-6 6-6 6 2.69 6 6"></path>
  </symbol>
</svg>
<footer class="is-full">
  <div class="footer--full">
    <div class="container">
      <div class="row">
        <div class="col-md-4">
          <div class="row">
            <div class="col-sm-6 col-md-12 div-logo">
              <a href="#"><img :src="'./static/img/DentalFind-logo-Branca.png'" class="logo"></a>
            </div>
            <div class="col-xs-12 col-sm-6 col-md-12">
              <div class="row">
                <div class="col-xs-6 col-xs-push-6 col-sm-12 col-sm-push-0 footer-contact-info">
                  <div>Atendimento:</div>
                  <div>+55 85 2332 8832 <em>(Seg - Sext, 9am - 18pm)</em></div>
                  <div>Email: dentalfind@dfind.com</div>
                </div>
                <div class="col-xs-6 col-xs-pull-6 col-sm-12 col-sm-pull-0">
                  <ul class="footer-social footer-social-icons">
                    <li><a href="https://www.facebook.com/madson.chavante" rel="noopener" target="_blank">
                        <svg width="24" height="24">
                          <use xlink:href="#c-icons--facebook"></use>
                        </svg></a></li>
                    <li><a href="#" rel="noopener" target="_blank">
                        <svg width="24" height="24">
                          <use xlink:href="#c-icons--instagram"></use>
                        </svg></a></li>
                    <li><a class="social-icon social-twitter" href="#"></a></li>
                  </ul>
                </div>
              </div>
            </div>
          </div>
        </div>
        <div class="col-sm-6 col-md-4">
          <div class="row">

          </div>
        </div>
        <div class="col-sm-6 col-md-4">
          <div class="row">
            <div class="col-xs-6">
              <dl class="footer-list">
                <dt>Atendimento ao consumidor</dt>
                <dd>Ajuda ao vivo</dd>
                <dd>Fale conosco</dd>
                <dd>Telefone: 85(8888-8888)</dd>
              </dl>
            </div>
            <div class="col-xs-6">
              <dl class="footer-list">
                <dt>Atendimento ao lojista</dt>
                <dd>Email: suportedfind@dfind.com</dd>
              </dl>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
  <div class="footer">
    <div class="container">
      <div class="copyright">Copyright © 2018-2018, Madson & Iago. Todos os direitos reservados</div>
    </div>
  </div>
</footer>

</div>
</template>

<script>

export default {
  name: 'Rodape',
}
</script>
<style scoped>
/* Updated version - 24th Nov 2014 */

*,
:after,
:before {
  -webkit-box-sizing: border-box;
  -moz-box-sizing: border-box;
  box-sizing: border-box;
}
html {
  font-size: 10px;
}
a {
  background-color: transparent;
  text-decoration: none;
}
article,
aside,
details,
figcaption,
figure,
footer,
header,
hgroup,
main,
menu,
nav,
section,
summary {
  display: block;
}
body {
  font-family: 'Muli', -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, 'Noto Sans', Ubuntu, 'Droid Sans', 'Helvetica Neue', Arial, sans-serif;
  font-size: 14px;
  line-height: 1.42857143;
  color: #333;
  background-color: #fff;
  margin: 0;
}
dl {
  margin-top: 0;
  margin-bottom: 20px;
}
dd,
dt {
  line-height: 1.42857143;
}
dt {
  font-weight: 700;
}
dd {
  margin-left: 0;
}
.row {
  margin-left: -15px;
  margin-right: -15px;
  display: flex;
}
.row:before,
.container:before,
.row:after,
.container:after {
  clear: both;
  content: " ";
  display: table;
}
.container {
  padding-right: 15px;
  padding-left: 15px;
  margin-right: auto;
  margin-left: auto;
}
@media (min-width: 768px) {
  .container {
    width: 750px;
  }
}
@media (min-width: 992px) {
  .container {
    width: 970px;
  }
}
@media (min-width: 1200px) {
  .container {
    width: 1170px;
  }
}
.text-center {
  text-align: center;
}
[class*="col-xs-"],
[class*="col-sm-"],
[class*="col-md-"],
[class*="col-lg-"] {
  position: relative;
  min-height: 1px;
  padding-right: 15px;
  padding-left: 15px;
}
[class*="col-xs-"] {
  float: left;
}
.col-xs-6 {
  width: 50%;
}
.col-xs-12 {
  width: 100%;
}
.col-xs-push-6 {
  left: 50%;
}
.col-xs-pull-6 {
  right: 50%;
}
@media (min-width: 768px) {
  [class*="col-sm-"] {
    float: left;
  }
  .col-sm-6 {
    width: 50%;
  }
  .col-sm-12 {
    width: 100%;
  }
  .col-sm-push-0 {
    left: auto;
  }
  .col-sm-pull-0 {
    right: auto;
  }
  .logo{
  width: 15em !important;
  margin-left: -1.9em !important;

}
}
@media (min-width: 992px) {
  [class*="col-md-"] {
    float: left;
  }
  .col-md-4 {
    width: 50%;
  }
  .col-md-10 {
    width: 83.33333333%;
  }
  .col-md-12 {
    width: 100%;
  }
  .col-md-offset-1 {
    margin-left: 8.33333333%;
  }
}
@media (max-width: 767px) {
  .hidden-xs {
    display: none !important;
  }
  .div-logo{
    display: none !important;
  }
}
label {
  cursor: pointer;
}
footer {
  position: relative;
  color: white;
  margin-top: 1rem;
}
footer a,
footer a:hover {
  color: white;
}
footer dt {
  color: #5bcbfb;
}
footer dd {
  margin-top: 1rem;
}

.footer--full {
  background-color: #24b1bb;
  display: none;
}
.is-full .footer--full {
  display: block;
  padding-top: 3rem;
}
.footer {
  background-color: #0b4a84;
  color: white;
  font-size: 0.75rem;
  padding-top: 0.25rem;
  padding-bottom: 0.25rem;
}
.footer .container {
  padding-top: 0.75rem;
  padding-bottom: 0.25rem;
  display: flex;
  flex-direction: column-reverse;
  text-align: center;
  justify-content: space-between;
  position: relative;
}
.footer .container:before {
  position: absolute;
  top: -0.25rem;
  left: 1rem;
  right: 1rem;
  background-color: #85a4c1;
  content: "";
  display: block;
  height: 0.5rem;
}
.is-full .footer .container:before {
  display: none;
}
.footer .container:after {
  content: none;
}
@media (min-width: 768px) {
  .footer .container {
    flex-direction: row;
  }
  .footer .container:before {
    left: 0;
    right: 0;
  }
}
.is-full .footer {
  font-family: -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, Oxygen, Ubuntu, Cantarell, 'Open Sans', 'Helvetica Neue', sans-serif;
  background-color: #1e9aa3;
  color: #fff;
}
.footer-logo {
  margin-top: 1.5rem;
  margin-bottom: 12px;
}
.footer-logo a {
  background-image: url("data:image/svg+xml,%3Csvg%20xmlns%3D%22http%3A%2F%2Fwww.w3.org%2F2000%2Fsvg%22%20viewBox%3D%223%2010.6%20308%2075.6%22%3E%3Cpath%20fill%3D%22%23fff%22%20d%3D%22M223.3%2034.1c6.4%200%2011.7-5.3%2011.7-11.8s-5.2-11.8-11.7-11.8H192v62.9h31.4c10.8%200%2019.6-8.8%2019.6-19.6%200-10.9-8.8-19.7-19.7-19.7m-98.8%2014.7c-1.8-.4-5.8-.7-5.8-3.2%200-1.9%202.6-2.5%204-2.5%202.3%200%205%20.7%207%201.8l4.4-8.3c-3.8-1.7-8-2.4-12.1-2.4-8.1%200-16.2%204-16.2%2013.1%200%206.5%204%208.6%208.2%209.6%204%201.1%208.2%201.2%208.2%204%200%202-2.4%202.8-4%202.8-3.1%200-7.3-1.7-9.9-3.4-1%203.3-2.7%206.3-5.1%208.8v.1c4.4%202.7%209.6%204.3%2014.9%204.3%208.6%200%2017.3-4%2017.3-13.7-.2-6.9-4.9-9.8-10.9-11%22%2F%3E%3Cpath%20fill%3D%22%23fff%22%20d%3D%22M86.9%2034.2c-2.8%200-5.5.6-8%201.7V22.4H67.4v32c.5%2010.5%209%2018.8%2019.5%2018.8%2010.8%200%2019.6-8.8%2019.6-19.6%200-10.7-8.8-19.4-19.6-19.4m.2%2027.5c-4.4%200-8-3.6-8-8s3.6-8%208-8%208%203.6%208%208-3.6%208-8%208M47.8%2034.2C37%2034.2%2028.2%2043%2028.2%2053.8S37%2073.4%2047.8%2073.4s19.6-8.8%2019.6-19.6c0-10.9-8.8-19.6-19.6-19.6m0%2027.5c-4.4%200-8-3.6-8-8s3.6-8%208-8%208%203.6%208%208-3.6%208-8%208M16.4%2034.1v33.6c-.6%203.7-3.7%206.7-7.6%206.8L3%2085.3c1.8.6%203.7.8%205.7.8%2010.3%200%2018.7-7.9%2019.5-18.1V34H16.4zm143.2-23.5h-23.5v62.9h23.5c17.4%200%2031.4-14%2031.4-31.4%200-17.5-14-31.5-31.4-31.5m101.8%2055.1c-.6%201.3-1.9%202.1-3.3%202.1-2%200-3.8-1.7-3.8-3.7s1.6-3.7%203.8-3.7c1.5%200%202.7%201%203.3%202.1.3-2.1%201.2-4%202.5-5.6-1.6-1.3-3.6-2.1-5.8-2.1-5.1%200-9.2%204.2-9.2%209.1%200%205.1%204.2%209.1%209.2%209.1%202.3%200%204.3-.8%205.8-2-1.3-1.3-2.2-3.2-2.5-5.3%22%2F%3E%3Cpath%20fill%3D%22%23fff%22%20d%3D%22M272.6%2055c-5.1%200-9.1%204.2-9.1%209.2%200%205.1%204.2%209.1%209.1%209.1%205.1%200%209.1-4.2%209.1-9.1%200-5.2-4.1-9.2-9.1-9.2m0%2013c-2%200-3.7-1.7-3.7-3.7s1.7-3.8%203.7-3.8%203.7%201.7%203.7%203.8c-.1%201.9-1.7%203.7-3.7%203.7m-25.4%201.5c0%202.2-1.7%203.8-3.8%203.8s-3.8-1.8-3.8-3.8c0-2.1%201.7-3.8%203.8-3.8s3.8%201.8%203.8%203.8M302.9%2055c-2.3%200-4.3%201-5.8%202.4-1.5-1.4-3.6-2.4-5.8-2.4-4.5%200-8.2%203.6-8.4%208.1v10.3h5.7V63.3c0-1.4%201.3-2.6%202.7-2.6%201.6%200%202.7%201.2%202.7%202.7v10h6.1v-10c0-1.5%201.2-2.7%202.7-2.7%201.5%200%202.7%201.2%202.7%202.7v10h5.6v-10c.2-4.6-3.6-8.4-8.2-8.4%22%2F%3E%3C%2Fsvg%3E");
  background-repeat: no-repeat;
  background-size: contain;
  display: block;
  text-indent: -5000px;
  height: 76px;
}
.footer-contact-info {
  color: #59cbfb;
  font-size: 0.75rem;
  margin: 1rem 0;
  font-family: -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, Oxygen, Ubuntu, Cantarell, 'Open Sans', 'Helvetica Neue', sans-serif;
}
.footer-contact-info em {
  color: #fff;
  font-style: normal;
  white-space: nowrap;
}
.footer-social {
  padding-left: 0;
  margin: 1rem 0;
}
.footer-social li {
  display: inline;
  line-height: 1;
}
svg {
  fill: #77CAF1;
}
svg.init {
  display: none;
}
.social-icon {
  background-image: url(data:image/svg+xml,%3C%3Fxml%20version%3D%221.0%22%20encoding%3D%22utf-8%22%3F%3E%0D%0A%3C%21--%20Generator%3A%20Adobe%20Illustrator%2015.0.2%2C%20SVG%20Export%20Plug-In%20.%20SVG%20Version%3A%206.00%20Build%200%29%20%20--%3E%0D%0A%3C%21DOCTYPE%20svg%20PUBLIC%20%22-%2F%2FW3C%2F%2FDTD%20SVG%201.1%2F%2FEN%22%20%22http%3A%2F%2Fwww.w3.org%2FGraphics%2FSVG%2F1.1%2FDTD%2Fsvg11.dtd%22%20%5B%0D%0A%09%3C%21ENTITY%20st0%20%22fill%3A%23072E58%3B%22%3E%0D%0A%09%3C%21ENTITY%20st1%20%22fill%3A%2377CAF1%3B%22%3E%0D%0A%5D%3E%0D%0A%3Csvg%20version%3D%221.1%22%20id%3D%22Layer_1%22%20xmlns%3D%22http%3A%2F%2Fwww.w3.org%2F2000%2Fsvg%22%20xmlns%3Axlink%3D%22http%3A%2F%2Fwww.w3.org%2F1999%2Fxlink%22%20x%3D%220px%22%20y%3D%220px%22%0D%0A%09%20width%3D%2226px%22%20height%3D%22270px%22%20viewBox%3D%220%200%2026%20270%22%20style%3D%22enable-background%3Anew%200%200%2026%20270%3B%22%20xml%3Aspace%3D%22preserve%22%3E%0D%0A%3Cg%3E%0D%0A%09%3Cpath%20style%3D%22%26st1%3B%22%20d%3D%22M4%2C240c-2.2%2C0-4%2C1.8-4%2C4v18c0%2C2.2%2C1.8%2C4%2C4%2C4h18c2.2%2C0%2C4-1.8%2C4-4v-18c0-2.2-1.8-4-4-4H4L4%2C240z%22%2F%3E%0D%0A%09%3Cpath%20style%3D%22%26st0%3B%22%20d%3D%22M19.7%2C249.6C20%2C250.7%2C20%2C253%2C20%2C253s0%2C2.3-0.3%2C3.4c-0.2%2C0.6-0.6%2C1.1-1.2%2C1.2c-1.1%2C0.3-5.5%2C0.3-5.5%2C0.3%0D%0A%09%09s-4.4%2C0-5.5-0.3c-0.6-0.2-1.1-0.6-1.2-1.2C6%2C255.3%2C6%2C253%2C6%2C253s0-2.3%2C0.3-3.4c0.2-0.6%2C0.6-1.1%2C1.2-1.2c1.1-0.3%2C5.5-0.3%2C5.5-0.3%0D%0A%09%09s4.4%2C0%2C5.5%2C0.3C19.1%2C248.5%2C19.5%2C249%2C19.7%2C249.6%20M15.2%2C253l-3.7-2.1v4.2L15.2%2C253z%22%2F%3E%0D%0A%3C%2Fg%3E%0D%0A%3Cg%3E%0D%0A%09%3Cpath%20style%3D%22%26st1%3B%22%20d%3D%22M4%2C0C1.8%2C0%2C0%2C1.8%2C0%2C4v18c0%2C2.2%2C1.8%2C4%2C4%2C4h18c2.2%2C0%2C4-1.8%2C4-4V4c0-2.2-1.8-4-4-4H4z%22%2F%3E%0D%0A%09%3Cpath%20style%3D%22%26st0%3B%22%20d%3D%22M11.2%2C8.7v1.9H9.8V13h1.4v7H14v-7h1.9c0%2C0%2C0.2-1.1%2C0.3-2.4H14V9c0%2C0%2C0.3-0.6%2C0.6-0.6h1.6V6h-2.1%0D%0A%09%09C11.1%2C6%2C11.2%2C8.4%2C11.2%2C8.7z%22%2F%3E%0D%0A%3C%2Fg%3E%0D%0A%3Cg%3E%0D%0A%09%3Cpath%20style%3D%22%26st1%3B%22%20d%3D%22M0%2C52c0%2C2.2%2C1.8%2C4%2C4%2C4h18c2.2%2C0%2C4-1.8%2C4-4V34c0-2.2-1.8-4-4-4H4c-2.2%2C0-4%2C1.8-4%2C4V52z%22%2F%3E%0D%0A%09%3Cpath%20style%3D%22%26st0%3B%22%20d%3D%22M10.4%2C48.7c5.3%2C0%2C8.2-4.4%2C8.2-8.2c0-0.1%2C0-0.2%2C0-0.4c0.6-0.4%2C1-0.9%2C1.4-1.5c-0.5%2C0.2-1.1%2C0.4-1.7%2C0.5%0D%0A%09%09c0.6-0.4%2C1-0.9%2C1.3-1.6c-0.6%2C0.3-1.2%2C0.6-1.8%2C0.7c-1.1-1.2-2.9-1.2-4.1-0.1c-0.7%2C0.7-1.1%2C1.7-0.8%2C2.7c-2.3-0.1-4.5-1.2-5.9-3%0D%0A%09%09c-0.8%2C1.3-0.4%2C3%2C0.9%2C3.8c-0.5%2C0-0.9-0.1-1.3-0.4v0c0%2C1.4%2C1%2C2.5%2C2.3%2C2.8c-0.4%2C0.1-0.9%2C0.1-1.3%2C0c0.4%2C1.2%2C1.5%2C2%2C2.7%2C2%0D%0A%09%09c-1%2C0.8-2.3%2C1.2-3.6%2C1.2c-0.2%2C0-0.5%2C0-0.7%2C0C7.3%2C48.2%2C8.8%2C48.7%2C10.4%2C48.7%22%2F%3E%0D%0A%3C%2Fg%3E%0D%0A%3Cg%3E%0D%0A%09%3Cpath%20style%3D%22%26st1%3B%22%20d%3D%22M0%2C82c0%2C2.2%2C1.8%2C4%2C4%2C4h18c2.2%2C0%2C4-1.8%2C4-4V64c0-2.2-1.8-4-4-4H4c-2.2%2C0-4%2C1.8-4%2C4V82z%22%2F%3E%0D%0A%09%3Cpath%20style%3D%22%26st0%3B%22%20d%3D%22M14.8%2C72.1h-1.9h-2.5v1.9h2.5c-0.4%2C1-1.3%2C1.7-2.4%2C1.7c-1.4%2C0-2.6-1.2-2.6-2.6s1.2-2.6%2C2.6-2.6%0D%0A%09%09c0.6%2C0%2C1.2%2C0.2%2C1.7%2C0.6l1.3-1.3c-0.8-0.7-1.8-1.2-3-1.2C8%2C68.6%2C6%2C70.5%2C6%2C73s2%2C4.4%2C4.4%2C4.4s4.4-2%2C4.4-4.4%0D%0A%09%09C14.9%2C72.7%2C14.8%2C72.4%2C14.8%2C72.1L14.8%2C72.1L14.8%2C72.1z%20M18.5%2C72.2v-1.5h-1.1v1.5h-1.5v1.1h1.5v1.5h1.1v-1.5H20v-1.1H18.5z%22%2F%3E%0D%0A%3C%2Fg%3E%0D%0A%3Cg%3E%0D%0A%09%3Cpath%20style%3D%22%26st1%3B%22%20d%3D%22M0%2C112c0%2C2.2%2C1.8%2C4%2C4%2C4h18c2.2%2C0%2C4-1.8%2C4-4V94c0-2.2-1.8-4-4-4H4c-2.2%2C0-4%2C1.8-4%2C4V112z%22%2F%3E%0D%0A%09%3Cpath%20style%3D%22%26st0%3B%22%20d%3D%22M13.8%2C108.6c0-0.2-0.1-0.4-0.3-0.6c-0.2-0.2-0.4-0.3-0.6-0.3c-0.2%2C0-0.4%2C0.1-0.6%2C0.3%0D%0A%09%09c-0.2%2C0.2-0.3%2C0.4-0.3%2C0.6c0%2C0.2%2C0.1%2C0.5%2C0.3%2C0.6c0.2%2C0.2%2C0.4%2C0.3%2C0.6%2C0.3c0.2%2C0%2C0.5-0.1%2C0.6-0.3C13.7%2C109%2C13.8%2C108.8%2C13.8%2C108.6z%0D%0A%09%09%20M16.1%2C106.8v-7.7c0-0.1%2C0-0.2-0.1-0.2c-0.1-0.1-0.1-0.1-0.2-0.1h-5.6c-0.1%2C0-0.2%2C0-0.2%2C0.1c-0.1%2C0.1-0.1%2C0.2-0.1%2C0.3v7.7%0D%0A%09%09c0%2C0.1%2C0%2C0.2%2C0.1%2C0.3s0.2%2C0.1%2C0.3%2C0.1h5.6c0.1%2C0%2C0.2%2C0%2C0.3-0.1C16.1%2C107%2C16.1%2C106.9%2C16.1%2C106.8z%20M14%2C97.5c0-0.1-0.1-0.2-0.2-0.2%0D%0A%09%09h-1.7c-0.1%2C0-0.2%2C0.1-0.2%2C0.2c0%2C0.1%2C0.1%2C0.2%2C0.2%2C0.2h1.8C13.9%2C97.7%2C14%2C97.7%2C14%2C97.5z%20M17.2%2C97.4v11.2c0%2C0.4-0.1%2C0.7-0.4%2C1%0D%0A%09%09c-0.3%2C0.3-0.6%2C0.4-1%2C0.4h-5.6c-0.4%2C0-0.7-0.1-1-0.4c-0.3-0.3-0.4-0.6-0.4-1V97.4c0-0.4%2C0.1-0.7%2C0.4-1c0.3-0.3%2C0.6-0.4%2C1-0.4h5.6%0D%0A%09%09c0.4%2C0%2C0.7%2C0.1%2C1%2C0.4C17%2C96.7%2C17.2%2C97%2C17.2%2C97.4z%22%2F%3E%0D%0A%3C%2Fg%3E%0D%0A%3Cg%3E%0D%0A%09%3Cpath%20style%3D%22%26st1%3B%22%20d%3D%22M0%2C142c0%2C2.2%2C1.8%2C4%2C4%2C4h18c2.2%2C0%2C4-1.8%2C4-4v-18c0-2.2-1.8-4-4-4H4c-2.2%2C0-4%2C1.8-4%2C4V142z%22%2F%3E%0D%0A%09%3Cpath%20style%3D%22%26st0%3B%22%20d%3D%22M9.1%2C140H6.2v-9.3h2.9V140z%20M7.7%2C129.4c-0.9%2C0-1.7-0.8-1.7-1.7c0-0.9%2C0.8-1.7%2C1.7-1.7c0.9%2C0%2C1.7%2C0.8%2C1.7%2C1.7%0D%0A%09%09C9.4%2C128.6%2C8.6%2C129.4%2C7.7%2C129.4z%20M20%2C140h-2.9v-4.5c0-1.1%2C0-2.5-1.5-2.5c-1.5%2C0-1.7%2C1.2-1.7%2C2.4v4.6H11v-9.3h2.8v1.3h0%0D%0A%09%09c0.4-0.7%2C1.3-1.5%2C2.7-1.5c2.9%2C0%2C3.5%2C1.9%2C3.5%2C4.4V140z%22%2F%3E%0D%0A%3C%2Fg%3E%0D%0A%3Cg%3E%0D%0A%09%3Cpath%20style%3D%22%26st1%3B%22%20d%3D%22M0%2C172c0%2C2.2%2C1.8%2C4%2C4%2C4h18c2.2%2C0%2C4-1.8%2C4-4v-18c0-2.2-1.8-4-4-4H4c-2.2%2C0-4%2C1.8-4%2C4V172z%22%2F%3E%0D%0A%09%3Cpath%20style%3D%22%26st0%3B%22%20d%3D%22M11.9%2C167.8c-2.3%2C0.2-4.3-0.8-4.5-2.3c-0.2-1.5%2C1.6-2.9%2C3.9-3.2c2.3-0.2%2C4.3%2C0.8%2C4.5%2C2.3%0D%0A%09%09S14.2%2C167.6%2C11.9%2C167.8%20M16.5%2C162.8c-0.2-0.1-0.3-0.1-0.2-0.4c0.2-0.6%2C0.2-1%2C0-1.4c-0.5-0.6-1.7-0.6-3.1%2C0c0%2C0-0.4%2C0.2-0.3-0.2%0D%0A%09%09c0.2-0.7%2C0.2-1.3-0.2-1.6c-0.8-0.8-2.8%2C0-4.6%2C1.8c-1.3%2C1.3-2.1%2C2.7-2.1%2C3.9c0%2C2.3%2C3%2C3.7%2C5.9%2C3.7c3.8%2C0%2C6.3-2.2%2C6.3-4%0D%0A%09%09C18.2%2C163.6%2C17.3%2C163%2C16.5%2C162.8%20M19%2C158.6c-0.9-1-2.3-1.4-3.5-1.1h0c-0.3%2C0.1-0.5%2C0.3-0.4%2C0.6c0.1%2C0.3%2C0.3%2C0.5%2C0.6%2C0.4%0D%0A%09%09c0.9-0.2%2C1.9%2C0.1%2C2.5%2C0.8c0.7%2C0.7%2C0.8%2C1.7%2C0.6%2C2.6v0c-0.1%2C0.3%2C0.1%2C0.6%2C0.3%2C0.7c0.3%2C0.1%2C0.6-0.1%2C0.7-0.3c0%2C0%2C0%2C0%2C0%2C0%0D%0A%09%09C20.2%2C161%2C20%2C159.6%2C19%2C158.6%20M17.6%2C159.8c-0.4-0.5-1.1-0.7-1.7-0.6c-0.3%2C0.1-0.4%2C0.3-0.4%2C0.5c0.1%2C0.2%2C0.3%2C0.4%2C0.5%2C0.4l0%2C0%0D%0A%09%09c0.3-0.1%2C0.6%2C0%2C0.8%2C0.3c0.2%2C0.2%2C0.3%2C0.6%2C0.2%2C0.9l0%2C0c-0.1%2C0.2%2C0.1%2C0.5%2C0.3%2C0.6c0.2%2C0.1%2C0.5-0.1%2C0.6-0.3%0D%0A%09%09C18.2%2C161%2C18.1%2C160.3%2C17.6%2C159.8%20M12%2C165.1c-0.1%2C0.1-0.3%2C0.2-0.4%2C0.1c-0.1-0.1-0.2-0.2-0.1-0.3c0.1-0.1%2C0.3-0.2%2C0.4-0.1%0D%0A%09%09C12%2C164.8%2C12.1%2C164.9%2C12%2C165.1%20M11.3%2C166c-0.2%2C0.4-0.7%2C0.5-1.1%2C0.3c-0.4-0.2-0.5-0.6-0.2-0.9c0.2-0.3%2C0.7-0.5%2C1-0.4%0D%0A%09%09C11.4%2C165.3%2C11.5%2C165.7%2C11.3%2C166%20M12.1%2C163.5c-1.1-0.3-2.3%2C0.3-2.8%2C1.2c-0.5%2C1%2C0%2C2.1%2C1.1%2C2.5c1.2%2C0.4%2C2.5-0.2%2C3-1.3%0D%0A%09%09C13.8%2C164.9%2C13.3%2C163.8%2C12.1%2C163.5%22%2F%3E%0D%0A%3C%2Fg%3E%0D%0A%3Cg%3E%0D%0A%09%3Cpath%20style%3D%22%26st1%3B%22%20d%3D%22M0%2C202c0%2C2.2%2C1.8%2C4%2C4%2C4h18c2.2%2C0%2C4-1.8%2C4-4v-18c0-2.2-1.8-4-4-4H4c-2.2%2C0-4%2C1.8-4%2C4V202z%22%2F%3E%0D%0A%09%3Cpath%20style%3D%22%26st0%3B%22%20d%3D%22M19.9%2C191.7l-0.1-0.2l-0.2-0.1c-0.3-0.2-1.6%2C0-1.9-0.3c-0.2-0.2-0.3-0.6-0.4-1.2c-0.1-1.1-0.2-1.1-0.4-1.5%0D%0A%09%09c-0.6-1.3-2.3-2.3-3.4-2.4h-3.1C8%2C186%2C6%2C188%2C6%2C190.4v5.2c0%2C2.4%2C2%2C4.4%2C4.4%2C4.4h5.1c2.4%2C0%2C4.4-2%2C4.4-4.4V191.7z%20M10.5%2C189.5H13%0D%0A%09%09c0.5%2C0%2C0.9%2C0.4%2C0.9%2C0.9s-0.4%2C0.9-0.8%2C0.9h-2.5c-0.5%2C0-0.8-0.4-0.8-0.8C9.8%2C190.1%2C10%2C189.5%2C10.5%2C189.5L10.5%2C189.5z%20M15.4%2C196.2h-5%0D%0A%09%09c-0.5%2C0-0.8-0.4-0.8-0.8c0-0.5%2C0.4-0.8%2C0.9-0.8h5c0.5%2C0%2C0.8%2C0.4%2C0.8%2C0.9C16.3%2C195.9%2C15.9%2C196.2%2C15.4%2C196.2L15.4%2C196.2z%22%2F%3E%0D%0A%3C%2Fg%3E%0D%0A%3Cg%3E%0D%0A%09%3Cpath%20style%3D%22%26st1%3B%22%20d%3D%22M0%2C232c0%2C2.2%2C1.8%2C4%2C4%2C4h18c2.2%2C0%2C4-1.8%2C4-4v-18c0-2.2-1.8-4-4-4H4c-2.2%2C0-4%2C1.8-4%2C4V232z%22%2F%3E%0D%0A%09%3Cpath%20style%3D%22%26st0%3B%22%20d%3D%22M9.8%2C228c0%2C0.5-0.2%2C1-0.6%2C1.4S8.4%2C230%2C7.9%2C230s-1-0.2-1.3-0.6C6.2%2C229%2C6%2C228.6%2C6%2C228.1s0.2-1%2C0.6-1.3%0D%0A%09%09c0.4-0.4%2C0.8-0.6%2C1.4-0.6c0.5%2C0%2C1%2C0.2%2C1.4%2C0.6C9.6%2C227%2C9.8%2C227.5%2C9.8%2C228L9.8%2C228z%20M14.9%2C229.3c0%2C0.2%2C0%2C0.3-0.2%2C0.5%0D%0A%09%09c-0.1%2C0.1-0.3%2C0.2-0.5%2C0.2h-1.3c-0.2%2C0-0.3%2C0-0.4-0.2c-0.1-0.1-0.2-0.2-0.2-0.4c-0.1-1.5-0.8-2.8-1.8-3.9c-1.1-1.1-2.4-1.7-3.9-1.8%0D%0A%09%09c-0.2%2C0-0.3-0.1-0.4-0.2S6%2C223.2%2C6%2C223.1v-1.3c0-0.2%2C0.1-0.3%2C0.2-0.5c0.1-0.1%2C0.3-0.2%2C0.4-0.2h0.1c1.1%2C0.1%2C2.1%2C0.4%2C3%2C0.8%0D%0A%09%09c1%2C0.5%2C1.8%2C1.1%2C2.6%2C1.8c0.8%2C0.8%2C1.4%2C1.6%2C1.8%2C2.6C14.6%2C227.2%2C14.8%2C228.2%2C14.9%2C229.3L14.9%2C229.3z%20M20%2C229.3c0%2C0.2%2C0%2C0.3-0.2%2C0.5%0D%0A%09%09c-0.1%2C0.1-0.3%2C0.2-0.5%2C0.2h-1.4c-0.2%2C0-0.3-0.1-0.4-0.2c-0.1-0.1-0.2-0.3-0.2-0.4c-0.1-1.4-0.4-2.8-1-4.1c-0.6-1.3-1.4-2.4-2.3-3.3%0D%0A%09%09c-0.9-0.9-2.1-1.7-3.3-2.3c-1.3-0.6-2.6-0.9-4.1-1c-0.2%2C0-0.3-0.1-0.4-0.2S6%2C218.2%2C6%2C218.1v-1.4c0-0.2%2C0.1-0.3%2C0.2-0.5%0D%0A%09%09c0.1-0.1%2C0.3-0.2%2C0.4-0.2c1.7%2C0.1%2C3.4%2C0.5%2C5%2C1.2c1.6%2C0.7%2C3%2C1.7%2C4.2%2C2.9c1.2%2C1.2%2C2.2%2C2.6%2C2.9%2C4.2C19.5%2C225.9%2C19.9%2C227.5%2C20%2C229.3z%22%0D%0A%09%09%2F%3E%0D%0A%3C%2Fg%3E%0D%0A%3C%2Fsvg%3E%0D%0A);
  display: inline-block;
  margin-right: 0.25em;
  height: 26px;
  width: 26px;
  text-indent: -5000px;
}
.social-googleplus {
  background-position: 0 -60px;
}
.social-weibo {
  background-position: 0 -150px;
}
.social-twitter {
  background-position: 0 -30px;
}
.social-feed {
  background-position: 0 -210px;
}
.footer-list {
  margin: 20px;
  position: static;
  font-family: -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, Oxygen, Ubuntu, Cantarell, 'Open Sans', 'Helvetica Neue', sans-serif;
}

@media (max-width: 1000px) {
  .footer-list{
    display: none;
  }
}
@media (min-width: 768px) {
  .footer-list:not(.first):before {
    position: absolute;
    top: 0;
    left: -6px;
    display: inline-block;
    width: 2px;
    height: 200px;
    content: " ";
    border-right: 1px solid #094786;
    border-left: 1px solid #031426;
  }
}
.footer-list-horizontal {
  display: inline-block;
  font-size: 0.75rem;
  line-height: 1.333333;
}
.footer-list-horizontal dt,
.footer-list-horizontal dd {
  display: inline-block;
  margin: 0 0.5em 0 0;
}
.footer-list-horizontal dt:after,
.footer-list-horizontal dd:not(:last-child):after {
  margin-left: 0.5em;
  content: "|";
  color: #5bcbfb;
  font-weight: normal;
}
@supports (--css: variables) {
  :root {
    --list-font-size: 1rem;
    --local-text-align: center;
  }
  @media (min-width: 768px) {
    :root {
      --local-text-align: left;
    }
  }
  @media (min-width: 992px) {
    :root {
      --list-font-size: 0.875rem;
    }
  }
  footer {
    text-align: var(--local-text-align);
  }
  footer dd {
    font-size: var(--list-font-size);
  }
}
.copyright,
.base-links {
  padding: 0.5rem 1rem;
}
.copyright a,
.base-links a {
  display: inline-block;
}
.copyright a:not(:first-child),
.base-links a:not(:first-child) {
  margin-left: 1.4em;
  position: relative;
}
.copyright a:not(:first-child):before,
.base-links a:not(:first-child):before {
  position: absolute;
  top: 0;
  left: -0.8em;
  content: "|";
}
.is-full .copyright,
.is-full .base-links {
  padding-left: 0;
  padding-right: 0;
}
.is-full .copyright a,
.is-full .base-links a,
.is-full .copyright a:hover,
.is-full .base-links a:hover {
  color: #fff;
}


.logo{
  width: 30em;
  margin-left: -3.8em;
}


</style>
