import { createStore } from 'vuex';
//import axios from 'axios';

export const store = createStore({
  state: {
    livres: [{"idLivre":14004,"titre":"Livre1","isbm":"ref101","anneeEdition":2000,"resume":"livre111111","nombre":10,"image":"image210.jpg","empreint":[]},
    {"idLivre":14004,"titre":"Livre1","isbm":"ref101","anneeEdition":2000,"resume":"livre111111","nombre":10,"image":"image210.jpg","empreint":[]}],
    etudiants:[
      {"idEtudiant":1,"nom":"Rania","prenom":"hocine","classe":"Mastere"},
      {"idEtudiant":2,"nom":"katia","prenom":"hacene","classe":"Mastere"}
    ]
    
  },
  getters:{ 
    //livre
    listeLivre(state){
            return state.livres;
    },
    //etudiant
    listeEtudiant(state){
      return state.etudiants;
},
   
    
  },
  mutations:{
    //livre
      Livre(state,valeur){
        state.livres =  valeur;
      }, 
       Ajout_Livre(state,valeur){
         state.livres.push(valeur);
       },
       Delete_Livre(state,id){
         state.livres.splice(state.livres.indexOf(id), 1);
       },
       Livre_Id(state,valeur){
         state.livre=valeur;
       },
       //etudiants
       Etudiant(state,valeur){
         state.etudiants=valeur;
       },
       Delete_Etudiant(state,id){
        state.etudiants.splice(state.etudiants.indexOf(id), 1);

       }
       
  },
  actions:{
        //livre
      //  Get_Livre({commit}){
      //   axios.get("https://localhost:44300/api/livres")
      //   .then(res =>{
      //     commit('Livre',res.data.reverse());
      //   })
      //  },
       Get_Ajout({commit},val){
         commit('Ajout_Livre',val);
       },
       Get_Delete({commit},val){
         commit('Delete_Livre',val);
       },
       //etudiant
      //  Get_Etudiant({commit}){
      //   axios.get("https://localhost:44300/api/Etudiants")
      //   .then(res =>{
      //     commit('Etudiant',res.data.reverse());
      //   })
      //  },
        Get_Delete_Etudiant({commit},val){
        commit('Delete_Etudiant',val);
      },

       
      
     
  },
  
})


