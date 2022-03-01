<template>
  <ion-page>
    <base-layout>
      <template v-slot:slot-1>Gérer Etudiant</template>
      <template v-slot:slot-2>
        <ion-buttons slot="start">
          <ion-button color="danger">
            <ion-menu-button menu="main-menu"></ion-menu-button>
          </ion-button>
        </ion-buttons>
      </template>

      <template v-slot:slot-3>
        <ion-buttons slot="end">
          <ion-button color="danger" href="/ajouterEtudiant" >
            <ion-icon :icon="add" slot="icon-only"></ion-icon>
          </ion-button>
        </ion-buttons>
      </template>
      <template v-slot:slot-4>
        <ion-toolbar>
          <ion-searchbar  @ionInput="Shearsh = $event.target.value" animated>
          </ion-searchbar>
        </ion-toolbar>
      </template>
    </base-layout>

    <!--contenu de livre chercher-->

    <ion-content :fullscreen="true" v-if="EtudiantsSh"> 
      <br />
      <ion-list>
      <card-etudiant v-for="etudiant in EtudiantsSh" :key="etudiant.idEtudiant" :Etudiant="etudiant">

      </card-etudiant>
      </ion-list>

      
    </ion-content>

    <!--fin contenu de livre  chercher-->

    <!--contenu de tous les livre-->

    <ion-content :fullscreen="true" v-else>
      <br />
      <ion-list>
      <card-etudiant v-for="etudiant in listeEtudiant" :key="etudiant.idEtudiant" :Etudiant="etudiant">

      </card-etudiant>
      </ion-list>
     
    </ion-content>

    <!--fin contenu tous les livre -->
  </ion-page>
</template>

<script>
//import mapState from "vuex";
import { mapGetters } from 'vuex' 
import BaseLayout from "../components/BaseLayout.vue";
import CardEtudiant from "../components/CardEtudiant.vue";
import { IonPage, IonIcon, IonButtons, IonButton } from "@ionic/vue";
import { star, trash, cart, add, openOutline } from "ionicons/icons";
import { defineComponent } from "vue";
//import axios from "axios";
export default defineComponent({
  data() {
    return {
      cart,
      trash,
      star,
      add,
      openOutline,
      livr: "",
      Shearsh: "",
      EtudiantsSh: "",
    };
  },
  computed:{
 ...mapGetters(['listeEtudiant'])
},
mounted(){
  
  this.$store.dispatch('Get_Etudiant');

},
  components: {
    IonPage,
    IonIcon,
    IonButtons,
    IonButton,
    BaseLayout,
    CardEtudiant
  },
  

  watch: {
    Shearsh() {
      if (this.Shearsh !== "") {
        this.EtudiantsSh = this.listeEtudiant.filter((s) =>
            s.prenom.startsWith(this.Shearsh) ||   s.nom.startsWith(this.Shearsh)        
        );
       
      } else {
        this.EtudiantsSh = "";
      }
    },
  },
});
</script>
<style>
ion-content {
  --padding-top: 80px;
}
</style>
