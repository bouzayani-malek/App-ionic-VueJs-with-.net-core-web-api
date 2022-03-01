<template>
  <ion-page>
    <base-layout>
      <template v-slot:slot-1>Bibliothéque</template>
      <template v-slot:slot-2>
        <ion-buttons slot="start">
          <ion-button color="danger">
            <ion-menu-button menu="main-menu"></ion-menu-button>
          </ion-button>
        </ion-buttons>
      </template>

      <template v-slot:slot-3> </template>
    </base-layout>
    <ion-content>
      
     <liste-etudiant :listeEtudiant="listeEtudiant"  ></liste-etudiant>
     <br>
     
    </ion-content>
    
    
  </ion-page>
</template>

<script>
import { mapGetters } from 'vuex' 
import BaseLayout from "../components/BaseLayout.vue";
import { IonPage, IonButtons, IonButton } from "@ionic/vue";
import { cart, add } from "ionicons/icons";
import { defineComponent } from "vue";
import listeEtudiant from "../components/ListeEtudiant.vue";
export default defineComponent({
  data() {
    return {
      cart,
      add,
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
    listeEtudiant,
    IonButtons,
    IonButton,
    BaseLayout,
  },
});
</script>
<style>
ion-content {
  --offset-top: 0;
}

</style>
