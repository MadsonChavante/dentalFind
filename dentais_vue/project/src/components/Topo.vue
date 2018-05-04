<template>
  <nav class="nav">
    <div id="menu" class="container">
      <div @click="toggleFunc()">
        <div class="bar1"></div>
        <div class="bar2"></div>
        <div class="bar3"></div>
      </div>
      <div id="menu-vertical" class="menu-vertical">
        <div class="nav_vertical">
          <router-link to="/cat" class="text" exact>Categorias</router-link>
        </div>
        <div class="nav_vertical">
          <router-link to="/cat" class="text" exact>Entrar</router-link>
        </div>
        <div class="nav_vertical">
          <router-link to="/cat" class="text" exact>Contato</router-link>
        </div>
      </div>
      <div class="img-home">
        <router-link to="/" class="text" exact><img class="home" src="@/assets/home.png" /></router-link>
      </div>
    </div>
  </nav>
</template>

<script>
export default {
  name: 'Topo',
  data () {
    return {
      msg: ''
    }
  },
  methods: {
    toggleFunc: function () {
      var e = document.getElementById('menu');
      var m = document.getElementById('menu-vertical');
      if (e.className == 'container change') {
        e.className = 'container';
        m.className = 'menu-vertical-fechado';
      }
      else {
        e.className = 'container change';
        m.className = 'menu-vertical-aberto';
      }
    }
  }
}
</script>

<style scoped>
.img-home {
  position: absolute;
  margin-left: 50px;
}
.home {
  margin: 6px 0;
  height: 20px;
  width: 20px;
}
.text {
  text-decoration: none;
  font-size: 18px;
  color: #333;
  font-family: -apple-system, BlinkMacSystemFont, "Segoe UI", Roboto, Oxygen,
    Ubuntu, Cantarell, "Open Sans", "Helvetica Neue", sans-serif;
}
.nav {
  z-index: 20;
  position: fixed;
  box-shadow: 0px 0px 15px #000;
  width: 100%;
  height: 40px;
  display: flex;
  flex-direction: row;
  background-color: white;
}
.bar1,
.bar2,
.bar3 {
  width: 20px;
  height: 2px;
  background-color: #333;
  margin: 6px 0;
  border-radius: 3px;
  transition: 0.2s;
}
.container {
  display: flex;
  margin: 5px;
  opacity: 1;
  transition: 0.2s;
}
.container:hover {
  opacity: 1;
}
#menu-vertical {
  position: absolute;
  align-items: center;
  flex-direction: column;
  padding: 0px;
  margin-top: 25px;
  margin-left: -15px;
  box-shadow: 0px 0px 15px #000;
  background-color: #ffffff;
}
.menu-vertical {
  display: flex;
  animation: modalOut 0s linear forwards;
}
.menu-vertical-aberto {
  opacity: 0;
  display: flex;
  animation: modalIn 0.2s linear forwards;
}
.menu-vertical-fechado {
  opacity: 1;
  animation: modalOut 0.2s linear forwards;
}
.nav_vertical {
  text-decoration: none;
  margin: 5px;
  margin-top: 6px;
  width: 90%;
  height: 30px;
  text-align: center;
  opacity: 0;
  transition: 0.9s 0.4s;
}
.nav_vertical:hover {
  transition: 0.5s;
  border-left: 8px solid #1c929b;
}

.menu-vertical-aberto .nav_vertical {
  opacity: 1;
}
.menu-vertical-fechado .nav_vertical {
  transition: 0.2s;
  opacity: 0;
  display: none;
}

.change .bar1 {
  -webkit-transform: translate(0px, 8px) rotate(-45deg);
  transform: translate(0px, 8px) rotate(-45deg);
}

.change .bar2 {
  opacity: 0;
}

.change .bar3 {
  -webkit-transform: translate(0, -8px) rotate(45deg);
  transform: translate(0, -8px) rotate(45deg);
}

@keyframes modalIn {
  0% {
    opacity: 0;
    height: 0px;
    width: 0px;
  }
  50% {
    opacity: 0;
  }
  100% {
    transform: translateY(20px);
    margin-left: 5px;
    padding: 10px;
    opacity: 1;
    height: 110px;
    width: 200px;
  }
}
@keyframes modalOut {
  from {
    margin-left: 5px;
    transform: translateY(20px);
    padding: 10px;
    opacity: 1;
    height: 110px;
    width: 200px;
  }
  50% {
    opacity: 0.3;
  }
  to {
    margin-left: 0px;
    transform: translateY(0px);
    padding: 0px;
    opacity: 0;
    height: 0px;
    width: 0px;
  }
}
</style>
