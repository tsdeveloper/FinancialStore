const HOST = "http://localhost:5001";

export const CONSTANST = {
  permissions: {},
  routes: {
    authorization: {
      login: HOST + "/api/auth/login",
      logout: HOST + "/api/auth/logout",
    },
    person: {
      list: HOST + "/api/person",
      save: HOST + "/api/person/save",
      update: HOST + "/api/person/:id/edit",
      getAll: HOST + "/api/person/all",
      get: HOST + "/api/person/:id",
      delete: HOST + "/api/person/:id/delete",
    },
  },
};
