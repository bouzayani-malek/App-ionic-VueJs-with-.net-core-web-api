<template>
  <ion-page>
    <base-layout>
      <template v-slot:slot-1>Detail Etudiant</template>
      <template v-slot:slot-2>
        <ion-buttons slot="start">
          <ion-button color="danger" href="/home">
            <ion-icon :icon="arrowBack" slot="icon-only"></ion-icon>
          </ion-button>
        </ion-buttons>
      </template>
    </base-layout>
    <ion-content>
        <ion-card>
  <ion-card-header>
      <ion-card-title> {{etudiant.data.nom}} {{etudiant.data.prenom}}</ion-card-title>
           <br>
    <ion-card-subtitle>Classe :{{etudiant.data.classe}}</ion-card-subtitle>
   
  </ion-card-header>
        </ion-card>

         <ion-card>
  <ion-card-header>
      <ion-card-title>Livre empreinter : {{etudiant.data.empreint.length}}</ion-card-title>
           <br>
    <h3>Livre en cour empreinter : {{nombreLivreEmreinter(etudiant.data.empreint)}}</h3>
    <ion-card-title v-for="livre in livreem(etudiant.data.empreint)" :key="livre.idLivre">livre :{{nomLivre(livre.idLivre)}}</ion-card-title>
  <br>
  <h3>Livre Remit  : {{nombreLivreRemit(etudiant.data.empreint)}}</h3>
    <ion-card-title v-for="liv in livreRe(etudiant.data.empreint)" :key="liv.idLivre">livre :{{nomLivreR(liv.idLivre)}}</ion-card-title>
  
  </ion-card-header>
        </ion-card>
        
    </ion-content>
  </ion-page>
</template>

<script>
//import { mapGetters } from 'vuex'
import BaseLayout from "../components/BaseLayout.vue";
import { IonPage, IonIcon, IonButtons, IonButton } from "@ionic/vue";
import { arrowBack } from "ionicons/icons";
import { defineComponent } from "vue";
import axios from "axios";

export default defineComponent({
  data() {
    return {
      arrowBack,
     nom:"",
     nn:"",
      etudiant: [],
    };
  },
  components: {
    IonPage,
    IonIcon,
    IonButtons,
    IonButton,
    BaseLayout,
  },
  async created() {
   this.etudiant= await axios
      .get("https://localhost:44300/api/Etudiants/" + this.$route.params.id)
      .then();
  },
  methods: {
    nombreLivreRemit(em){
      return em.filter(el=>el.au!=null).length;
    },
    livreRe(em){
        return em.filter(el=>el.au!=null);
     },
     livreem(em){
        return em.filter(el=>el.au==null);
     },
      nombreLivreEmreinter(em){
                return em.filter(el=>el.au==null).length;
      },
      nomLivre(id){
        
         axios.get("https://localhost:44300/api/Livres/"+id).then(res=>this.nom=res.data.titre);
          return this.nom;
      },
      nomLivreR(id){
        
         axios.get("https://localhost:44300/api/Livres/"+id).then(res=>this.nn=res.data.titre);
          return this.nn;
      }
      
    // FileSelected(event) {
    //   this.image = event.target.files[0];
    //   // upload image in to serveur
    //   let fd = new FormData();
    //   fd.append("image", this.image);
    //   axios
    //     .post("https://localhost:44300/api/livres/Image", fd)
    //     .then((res) => {
    //       this.image = res.data;
    //       console.log(res.data);
    //     })
    //     .catch((rer) => console.log(rer));
    // },
    // modifier() {
    //   // inserer livre dans base de donner
    //   let livre = {
    //     idLivre: this.$route.params.id,
    //     titre: this.titre,
    //     isbm: this.isbm,
    //     anneeEdition: this.annee,
    //     resume: this.resume,
    //     nombre: this.nombre,
    //     image: this.image,
    //   };

    //   axios
    //     .put(
    //       "https://localhost:44300/api/livres/" + this.$route.params.id,
    //       livre
    //     )
    //     .then((res) => console.log(res))
    //     .catch((rer) => console.log(rer));
    // },
  },
});
</script>
<style>
ion-input {
  border-radius: 20px !important;

  border: 1px solid #e5c234 !important;
  --background: #f6f9bf !important;
}
ion-label {
  color: red;
  font: 1.2em larger;
}
.app3 {
  width: 24%;
  margin-left: 40%;
  text-align: center;
  background-color: #e5c234;
  border-radius: 20px;
}
.item {
  --background: #f6f9bf !important;
  --border-radius: 20px;
  padding: 3px;

  --border-style: none;
}
</style>
