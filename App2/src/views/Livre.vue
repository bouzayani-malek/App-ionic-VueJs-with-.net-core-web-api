<template>
  <ion-page>
    <base-layout>
      <template v-slot:slot-1>Gérer Livre</template>
      <template v-slot:slot-2>
        <ion-buttons slot="start">
          <ion-button color="danger">
            <ion-menu-button menu="main-menu"></ion-menu-button>
          </ion-button>
        </ion-buttons>
      </template>

      <template v-slot:slot-3>
        <ion-buttons slot="end">
          <ion-button color="danger" href="/ajouter">
            <ion-icon :icon="add" slot="icon-only"></ion-icon>
          </ion-button>
        </ion-buttons>
      </template>
      <template v-slot:slot-4>
        <ion-toolbar>
          <ion-searchbar @ionInput="Shearsh = $event.target.value" animated>
          </ion-searchbar>
        </ion-toolbar>
      </template>
    </base-layout>

    <!--contenu de livre chercher-->

    <ion-content :fullscreen="true" v-if="livresSh">
      <card-layout
        v-for="item in livresSh"
        :key="item.idLivre"
        :livre="item"
       
      >
        <template v-slot:slot-1>
          <ion-button color="danger" @click="EditLivre(item.idLivre)">
            <ion-icon :icon="openOutline" slot="icon-only"> </ion-icon>
          </ion-button>
        </template>
      </card-layout>
    </ion-content>

    <!--fin contenu de livre  chercher-->

    <!--contenu de tous les livre-->

    <ion-content :fullscreen="true" v-else>
      <card-layout
        v-for="item in listeLivre"
        :key="item.idLivre"
        :livre="item"
        :nombreEmpreinte="nombreReste(item.idLivre)"
       
      >
        <template v-slot:slot-1>
          <ion-button color="danger" @click="EditLivre(item.idLivre)">
            <ion-icon :icon="openOutline" slot="icon-only"></ion-icon>
          </ion-button>
           
        </template>
      </card-layout>
     
    </ion-content>
 
    <!--fin contenu tous les livre -->
  </ion-page>
</template>

<script>
//import mapState from "vuex";
import { mapGetters } from 'vuex' 
import BaseLayout from "../components/BaseLayout.vue";
import CardLayout from "../components/CardLayout.vue";
import { IonPage, IonIcon, IonButtons, IonButton } from "@ionic/vue";
import { cart, add, openOutline } from "ionicons/icons";
import { defineComponent } from "vue";
//import axios from "axios";
export default defineComponent({
  data() {
    return {
      cart,
      add,
      openOutline,
      livr: "",    
      Shearsh: "",
      livresSh: "",
    };
  },
computed:{
 ...mapGetters(['listeLivre'])
},
mounted(){
  
  this.$store.dispatch('Get_Livre');

},
components: {
    IonPage,
    IonIcon,
    IonButtons,
    IonButton,
    BaseLayout,
    CardLayout,
  },
/*
  async created() {
    //get Livre
   // this.Livre = await axios.get("https://localhost:44300/api/livres");
    //console.log(this.Livre);
  },*/
  methods: {
    // supprimerLivre(livre) {
    //   this.Livre.data.splice(this.Livre.data.indexOf(livre), 1);
    // },
    EditLivre(id) {
      this.$router.push({ name: "EditLivre", params: { id: id } });
    },
    nombreReste(id){
      let l= this.listeLivre.filter(el=>el.idLivre==id);
     let r= l.map(el=>el.empreint)[0];
     return r.filter(el=>el.au==null).length;

    }
  },

  watch: {
    Shearsh() {
      if (this.Shearsh !== "") {
        // this.listeRecherche=1;
        this.livresSh = this.listeLivre.filter((s) =>
          s.titre.startsWith(this.Shearsh)||s.isbm.startsWith(this.Shearsh)
        );
      } else {
        this.livresSh = "";
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
