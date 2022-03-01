<template>
  <div class="stories">

    <div class="story" v-for="etudiant in listeEtudiant" :key="etudiant.idEtudiant">
      <div class="img-box" @click="DetailEtudiant()">
        <div class="sphere red">{{etudiant.nom[0].toUpperCase()}} {{etudiant.prenom[0].toUpperCase()}}</div>
      </div>
      <p>{{etudiant.nom}} {{etudiant.prenom}}</p>
    </div>

  </div>
</template>
<script>
export default {
  props:['listeEtudiant'],
  name: "listeEtudiant",
  methods:{
    DetailEtudiant(){
      //   this.$router.push({name:'Detail',params:{id:id}});
    }
  }
};
</script>
<style>
.stories {
  display: flex;
  overflow: scroll;
}
.stories .img-box {
  margin-right: 4px;
  background-size: contain;
  border-radius: 50%;
  padding: 4px;
}

.stories p {
  font-size: 15px;
  text-align: center;
  margin: 4px 0px 0px 0px;
  font-weight: 500;
  color: #383a3e;
}
.sphere {
  width: 100px;
  border-radius: 50%;
  text-align: center;
  vertical-align: middle;
  font-size: 300%;
  position: relative;
  box-shadow: inset -10px -10px 100px rgb(243, 188, 8),
    10px 10px 20px rgb(230, 226, 21), inset 0px 0px 10px rgb(164, 221, 32);
  display: inline-block;
  margin: 5%;
}
.red {
  background-color: red;
}
</style>