<template>
  <div class="hello">
    <Topo />
    <busca />
    <div class="contenier_produtos">
      <div class="card_produto">
        <div class="img_produto">
          <img src="https://dentalspeed.com/img.php?src=https://s3.amazonaws.com/www-dentalspeed-com/produtos/kit-academico-kavo-3.png&h=300&w=300" alt="">
        </div>
        <div class="info_produto">
          <h3>R$22,14</h3>
        </div>
      </div>
    </div>
  </div>
</template>

<script>

import Topo from '@/components/Topo'
import Busca from '@/components/Busca-logo'

export default {
  name: 'Home',
  components:{Topo,Busca},
  data () {
    return {
      msg: 'Welcome to Your Vue.js App'
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

.contenier_produto{
  display: flex;
  flex-direction: row;
  z-index: -1;
}
.card_produto{
  margin: 30px;
  width: 150px;
  height: 200px;
  background-color:#fff;
  box-shadow: 0px 0px 10px #c3c3c3;
}
.img_produto{
  display: flex;
  justify-content: center;
  z-index: -1;
}
.img_produto>img{
  width: 80%;
  height: 80%;
  -webkit-transition:1s;
}
.img_produto>img:hover{
  width: 100%;
  height: 100%;

}
.info_produto{
  height:76px;
  margin-top: -1px;
  border:solid 3px #f3f3f3;
}
.info_produto>h3{
  font-family: -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, Oxygen, Ubuntu, Cantarell, 'Open Sans', 'Helvetica Neue', sans-serif;
  margin-top: 10px;
  color: #24b1bb;
}
</style>
